$(document).ready(
    function() {
        var getParentContentId = function(el) {
            return $(el).parent('#content-view').attr('data-content-id');
        };

        var getContentView = function(id) {
            return $('div.content-view').find('[data-id="' + id + '"]');
        };

        var onCreateContentClick = function(e) {
            var title = $('#title').val();
            var text = $('#text').val();

            alert("title: " + title + " text: " + text);
        };

        var loadEditView = function(e) {
            var id = e.data.contentId;
            var contentView = getContentView(id);
            contentView.parent().load('/Node/ContentEdit/' + id);
            $('#btn-save-content').bind('click', onCreateContentClick);
        };

        var bindEditClick = function(e) {

        };

        var loadContentView = function(e) {
            var model = e.data.taskModel;
            $('div#node-content').load('/Node/Contents/' + model.id,
                function() {
                    $('a.btn-edit-content').each(function() {
                        var id = $(this).attr('data-id');
                        $(this).bind('click', { contentId: id }, loadEditView);
                    });
                });
        };

        $('div#node-content').empty();
        $('a.node-task').each(function() {
            var self = $(this);
            var id = self.attr('data-id');
            $.ajax({
                url: "/Node/GetTask/" + id,
                success: function(json) {
                    self.data('model', json);
                    self.bind("click", { taskModel: json, sender: self }, loadContentView);
                }
            });
        });
    });