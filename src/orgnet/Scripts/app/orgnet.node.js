$(document).ready(
    function() {
        var onSaveClick = function(e) {
            var title = $('#title').val();
            var text = $('#text').val();

            $.ajax({
                url: '/Node/UpdateContent',
                type: 'POST',
                dataType: 'json',
                data: { id: e.data.contentId, title: title, text: text },
                success: function(res) {
                    alert("response: " + JSON.stringify(res));
                }
            });
            //alert("title: " + title + " text: " + text + "id: " + e.data.contentId);
        };

        var loadEditView = function(e) {
            var id = e.data.contentId;
            var div = $('div.content-view[data-id="' + id + '"]').parent();
            div.empty();
            div.load('/Node/ContentEdit/' + id,
                function() {
                    $('#btn-save-content').bind('click', { contentId: id }, onSaveClick);
                });
        };

        var loadContentView = function(e) {
            var id = e.data.contentId;
            var div = $('div.content-edit[data-id="' + id + '"]').parent();
            div.empty();
            div.load('/Node/ContentView/' + id,
                function() {
                    $('#btn-save-content').bind('click', { contentId: id }, onSaveClick);
                });
        };

        var bindEditBtn = function(id) {
            var btn = $('a.btn-edit-content[data-id="' + id + '"]');
            btn.bind('click', { contentId: id }, loadEditView);
        };

        var loadTaskContents = function(e) {
            var model = e.data.taskModel;
            $('div#node-content').load('/Node/Contents/' + model.id,
                function() {
                    bindEditBtn(model.content);
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
                    self.bind("click", { taskModel: json }, loadTaskContents);
                }
            });
        });
    });