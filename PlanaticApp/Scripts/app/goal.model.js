(function (ko, datacontext) {
    datacontext.goalItem = goalItem;
    datacontext.goalList = goalList;

    function goalItem(data) {
        var self = this;
        data = data || {};

        // Persisted properties
        self.goalItemId = data.goalItemId;
        self.title = ko.observable(data.title);
        self.isDone = ko.observable(data.isDone);
        self.goalListId = data.goalListId;

        // Non-persisted properties
        self.errorMessage = ko.observable();

        saveChanges = function () {
            return datacontext.saveChangedGoalItem(self);
        };

        // Auto-save when these properties change
        self.isDone.subscribe(saveChanges);
        self.title.subscribe(saveChanges);

        self.toJson = function () { return ko.toJSON(self) };
    };

    function goalList(data) {
        var self = this;
        data = data || {};

        // Persisted properties
        self.goalListId = data.goalListId;
        self.userId = data.userId || "to be replaced";
        self.title = ko.observable(data.title || "My goals");
        self.goals = ko.observableArray(importGoalItems(data.goals));

        // Non-persisted properties
        self.isEditingListTitle = ko.observable(false);
        self.newGoalTitle = ko.observable();
        self.errorMessage = ko.observable();

        self.deleteGoal = function () {
            var goalItem = this;
            return datacontext.deleteGoalItem(goalItem)
                 .done(function () { self.goals.remove(goalItem); });
        };

        // Auto-save when these properties change
        self.title.subscribe(function () {
            return datacontext.saveChangedGoalList(self);
        });

        self.toJson = function () { return ko.toJSON(self) };
    };
    // convert raw goalItem data objects into array of goalItems
    function importGoalItems(goalItems) {
        /// <returns value="[new goalItem()]"></returns>
        return $.map(goalItems || [],
                function (goalItemData) {
                    return datacontext.createGoalItem(goalItemData);
                });
    }
    goalList.prototype.addGoal = function () {
        var self = this;
        if (self.newGoalTitle()) { // need a title to save
            var goalItem = datacontext.createGoalItem(
                {
                    title: self.newGoalTitle(),
                    goalListId: self.goalListId
                });
            self.goals.push(goalItem);
            datacontext.saveNewGoalItem(goalItem);
            self.newGoalTitle("");
        }
    };
})(ko, goalApp.datacontext);