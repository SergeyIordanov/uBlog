function clearReviewForm(clearAuthorBool) {
    var author = document.getElementById("review_author");
    var text = document.getElementById("review_text");
    text.setAttribute("value", "");
    if (clearAuthorBool) {
        author.setAttribute("value", "");
    }
}