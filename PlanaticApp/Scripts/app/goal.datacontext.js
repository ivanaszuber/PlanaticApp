window.planaticApp = window.planaticApp || {};

window.planaticApp.datacontext = (function () {

    var datacontext = {
        getGoalListDtoes: getGoalListDtoes,
        createGoalItem: createGoalItem,
        createGoalList: createGoalList,
        saveNewGoalItem: saveNewGoalItem,
        saveNewGoalList: saveNewGoalList,
        saveChangedGoalItem: saveChangedGoalItem,
        saveChangedTodoList: saveChangedGoalList,
        deleteGoalItem: deleteGoalItem,
        deleteGoalList: deleteGoalList
    };

    return datacontext;

    function getGoalListDtoes(goalListsObservable, errorObservable) {
        return ajaxRequest("get", goalListUrl())
            .done(getSucceeded)
            .fail(getFailed);

        function getSucceeded(data) {
            var mappedGoalList = $.map(data, function (list) { return new createGoalList(list); });
            goalListsObservable(mappedGoalList);
        }

        function getFailed() {
            errorObservable("Error retrieving goal lists.");
        }
    }
    function createGoalItem(data) {
        return new datacontext.goalItem(data); // goalItem is injected by todo.model.js
    }
    function createGoalList(data) {
        return new datacontext.goalList(data); // goalItem is injected by todo.model.js
    }
    function saveNewGoalItem(goalItem) {
        clearErrorMessage(goalItem);
        return ajaxRequest("post", goalItemUrl(), goalItem)
            .done(function (result) {
                goalItem.goalItemId = result.goalItemId;
            })
            .fail(function () {
                goalItem.errorMessage("Error adding a new goal item.");
            });
    }
    function saveNewGoalList(goalList) {
        clearErrorMessage(goalList);
        return ajaxRequest("post", goalListUrl(), goalList)
            .done(function (result) {
                goalList.goalListId = result.goalListId;
                goalList.userId = result.userId;
            })
            .fail(function () {
                goalList.errorMessage("Error adding a new goal list.");
            });
    }
    function deleteGoalItem(goalItem) {
        return ajaxRequest("delete", goalItemUrl(goalItem.goalItemId))
            .fail(function () {
                goalItem.errorMessage("Error removing goal item.");
            });
    }
    function deleteGoalList(goalList) {
        return ajaxRequest("delete", goalListUrl(goalList.goalListId))
            .fail(function () {
                goalList.errorMessage("Error removing todo list.");
            });
    }
    function saveChangedGoalItem(goalItem) {
        clearErrorMessage(goalItem);
        return ajaxRequest("put", goalItemUrl(goalItem.goalItemId), goalItem, "text")
            .fail(function () {
                goalItem.errorMessage("Error updating goal item.");
            });
    }
    function saveChangedGoalList(goalList) {
        clearErrorMessage(goalList);
        return ajaxRequest("put", goalListUrl(goalList.goalListId), goalList, "text")
            .fail(function () {
                goalList.errorMessage("Error updating the goal list title. Please make sure it is non-empty.");
            });
    }

    // Private
    function clearErrorMessage(entity) { entity.errorMessage(null); }
    function ajaxRequest(type, url, data, dataType) { // Ajax helper
        var options = {
            dataType: dataType || "json",
            contentType: "application/json",
            cache: false,
            type: type,
            data: data ? data.toJson() : null
        };
        var antiForgeryToken = $("#antiForgeryToken").val();
        if (antiForgeryToken) {
            options.headers = {
                'RequestVerificationToken': antiForgeryToken
            }
        }
        return $.ajax(url, options);
    }
    // routes
    function goalListUrl(id) { return "/api/goallist/" + (id || ""); }
    function goalItemUrl(id) { return "/api/goal/" + (id || ""); }

})();