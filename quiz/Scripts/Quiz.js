$(document).ready(function () {
    printListQuiz();


});
function selectQuiz(id) {
    $.ajax({
        type: 'POST',
        url: '/Quiz/SelectQuiz',
        dataType: "json",
        data: { quizId: id },
        success: function (data) {
            if (data["key"] == "OK")
                window.location.href = '/Question';
            else
                window.location.href = '/Result';
        }
    });

}
function printListQuiz() {
    $.ajax({
        type: 'POST',
        url: '/Quiz/ListQuiz',
        dataType: "json",
        success: function (data) {
            $.each(data, function (i) {
                $('#quizs').append('<div class="title">Quizs:</div>');
                $('#quizs').append('<div class="quiz"><a href="#" + onclick="selectQuiz(' + "'" + data[i].QuizId + "'" + ');">' + data[i].Description + '</div>');
            });
        }
    });
}