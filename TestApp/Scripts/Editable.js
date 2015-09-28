$(function () {
    $('.edit-mode').hide();
    $('.edit-book').on('click', function () {
        var tr = $(this).parents('tr:first');
        tr.find('.edit-mode, .display-mode').toggle();
    });
    $('.save-book').on('click', function () {
        var tr = $(this).parents('tr:first');
        var bookId = $(this).prop('id');
        var title = tr.find('#Title').val();
        var authorId = tr.find('#AuthorId').val();
        var categoryId = tr.find('#CategoryId').val();
        var isbn = tr.find('#ISBN').val();
        $.post(
            '/EditBook',
            { BookId: bookId, Title: title, AuthorId: authorId, CategoryId: categoryId, ISBN: isbn },
            function (book) {
                tr.find('#title').text(book.Title);
                tr.find('#authorname').text(book.AuthorName);
                tr.find('#category').text(book.Category);
                tr.find('#isbn').text(book.ISBN);
            }, "json");
        tr.find('.edit-mode, .display-mode').toggle();
    });
})