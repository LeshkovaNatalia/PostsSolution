$(document).ready(function () {
    var url = window.location.origin;
    debugger;
    $.ajax({
        type: 'GET',
        url: url + '/api/posts/postsasync',
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            var postsInJson = data;
            $.each(postsInJson, function (counter, post) {
                if (counter == 0) {
                    $("#posts").append('<tr style="text-align: justify;"><td width="200px"><b>Title</b></td><td width="700px"><b>Post</b></td><td width="200px"><b>Date</b></td><td width="300px"></td></tr>');
                }
                $("#posts").append('<tr sryle="background-color: whitesmoke;"><td width="200px">' + post.Name +
                    '</td><td width="700px">' + post.Text +
                    '</td><td width="200px">' + (post.CreatedOn ? new Date(post.CreatedOn).toDateString() : '') +
                    '</td><td width="300px"><a href="" onclick="DeletePost(' + post.Id + ');">Delete</a>|<input style="background-color: transparent; border: none;" type="button" id="btn' + post.Id + '" onclick="LoadCommentsForPost(' + post.Id + ')" value="Comments" />|<a href="/Comment/Create?postId=' + post.Id + '">Add Comment</a></td></tr><tr id="comments' + post.Id + '"></tr>');
            });
        },
        error: function (e) {
            alert(e.responseText);
        }
    });
});

function DeletePost(id) {
    var url = window.location.origin;
    var isDeleted = confirm('Are you sure you want to delete this Post?');

    if (isDeleted) {
        $.ajax({
            url: url + '/api/posts/remove/' + id,
            type: 'DELETE',
            success: function(data) {
                console.log('Post has been removed!');
            },
            error: function(data) {
                console.log('Problem in deleting post:' + data.responseText);
            }
        });
    }
};


function DeleteComment(id) {
    var url = window.location.origin;
    var isDeleted = confirm('Are you sure you want to delete this Commetn?');

    if (isDeleted) {
        $.ajax({
            url: url + '/api/comments/remove/' + id,
            type: 'DELETE',
            success: function (data) {
                console.log('Comment has been removed!');
            },
            error: function (data) {
                console.log('Problem in deleting comment:' + data.responseText);
            }
        });
    }
};

function LoadCommentsForPost(id) {
    var url = window.location.origin;

    $.ajax({
        type: 'GET',
        url: url + '/api/comments/GetCommentsForPost/' + id,
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            debugger;
            var commentsInJson = data;
            $.each(commentsInJson, function (counter, comment) {
                if (counter == 0) {
                    $("#btn".concat(comment.PostId)).hide();
                    $("#comments".concat(comment.PostId))
                        .before("<tr style='text-align: center;'><td><b>Comments for Post</b></td></tr>");
                    $("#comments".concat(comment.PostId))
                        .append('<td width="400px" style="background-color: light-gray; text-align: center;">' +
                            comment.Name +
                            '</td><td width="600px">' +
                            comment.Description +
                            '</td><td width="200px">' +
                            (comment.CreatedOn ? new Date(comment.CreatedOn).toDateString() : '') +
                            '</td><td width="200px"><a href="" onclick="DeleteComment(' +
                            comment.Id +
                            ');">Delete</a></td>');
                } else {
                    $("#comments".concat(comment.PostId))
                        .after('<tr><td width="400px" style="background-color: light-gray; text-align: center;">' +
                            comment.Name +
                            '</td><td width="500px">' +
                            comment.Description +
                            '</td><td width="200px">' +
                            (comment.CreatedOn ? new Date(comment.CreatedOn).toDateString() : '') +
                            '</td><td width="200px"><a href="" onclick="DeleteComment(' +
                            comment.Id +
                            ');">Delete</a></td><tr>');
                }
            });
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });  
}