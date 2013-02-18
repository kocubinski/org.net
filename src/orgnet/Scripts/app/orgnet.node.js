$(document).ready(
    function() {
        var onCreateContentClick = function(e) {
            var title = $('#title').val();
            var text = $('#text').val();

            alert("title: " + title + " text: " + text);
        };

        var loadEditView = function(e) {
            $('div#node-content').load('/Node/Content/' + e.data.nodeId);
            $('btn-create-content').bind('click', onCreateContentClick);
        };

        $('a.node-task').each(function() {
            $('div#node-content').empty();
            var id = $(this).attr('data-id');
            $(this).bind("click", { nodeId: id }, loadEditView);
        });
    });