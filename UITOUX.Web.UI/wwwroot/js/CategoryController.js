function CategoryController() {
    var self = this;
    var itemsInRow = 0;
    var requests = [];
    var actions = [];
    self.Categories = [];
    actions.push("/Category/FetchCategories");
    self.init = function (data) {
        for (var i = 0; i < actions.length; i++) {
            var ajaxConfig = {
                url: actions[i],
                method: 'GET',
            };
            requests.push($.ajax(ajaxConfig));
        }
        $.when.apply($, requests).done(function () {
            var responses = arguments;

            self.Categories = responses && responses[0].data ? responses[0].data : [];
           
            var categoryHtml = '';
            $.each(self.Categories, function (index, category) {
                var url = '/Product/GetProductsByCategory?categoryId=' + category.CategoryId;
                categoryHtml += '<a href="' + url + '" class="nav-item nav-link" data-category-id="' + category.CategoryId + '">' + category.Name + '</a>';
                addCategoryItem(category, url);
            });

            $('.categories').html(categoryHtml);

            //$.each(self.Categories, function (index, category) {
            //    var url = '/Product/GetProductsByCategory?categoryId=' + category.CategoryId;
            //    addCategoryItem(category, url);
                
            //});

           

            console.log(responses);

        }).fail(function () {
            console.log('One or more requests failed.');
        });
        // Function to add a category item
        function addCategoryItem(categrory,url) {
            console.log(categrory);
            var categoryItemHtml = '<div class="cat-item d-flex flex-column border mb-4" style="margin-right:25px; width:100px;">' +
                '<a href="' + url +'" class="cat-img position-relative overflow-hidden mb-3">' +
                '<img class="img-fluid" src="' + categrory.ImagePath + '">' +
                '</a>' +
                '</div>';

            $('#categoriesRow').append(categoryItemHtml);

            itemsInRow++;

            if (itemsInRow === 10) {
                $('#categoriesRow').append('<div class="row px-xl-5 pb-3" id="categoriesRow"></div>');

                // Reset the counter
                itemsInRow = 0;
            }
        }
    }
}