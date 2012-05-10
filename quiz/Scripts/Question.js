$(document).ready(function () { 
    printQuiz();
    showQuestion();
});
function send() {
    printQuiz();
    insertAnswer();
}
function showQuestion() {
    $.ajax({
        type: 'POST',
        url: '/Question/StartQuestion',
        dataType: "json",
        success: function (data) {
            printQuestion(data);            
        }
    });
}
function printQuestion(data) {
    $('#quest_count').empty();
    $('#questions').empty();
    var question = data.Question;
    $('#quest_count').append('Question:' + data.QuestionNumber +'/' + data.QuestionCount);
    var chars = new Array("A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L");
    $('#questions').append('<div class="title">' + question.Description + '</div>');
    var answers = question.Answers;
    $.each(answers, function (i) {
        $('#questions').append('<div class="answer"><strong>' + chars[i] + '</strong> <input type="radio" name="answerId" value="' + answers[i].AnswerId + '" />' + answers[i].Description + '</div><div class="clear"></div>');
    });
    $('#questions').append('<div class="bottom"> <button class="next" onclick="send()">Next Question</button></div>');
}
function printQuiz() {
    $('#quiz').empty();
    $.ajax({
        type: 'POST',
        url: '/Quiz/ShowQuiz',
        dataType: "json",
        success: function (data) {
            $('#quiz').append(data.Description);
        }
    });
}
function insertAnswer() {
    if ($('input[name=answerId]:checked').val() != null) {
        $.ajax({
            type: 'POST',
            url: '/Question/InsertAnswer',
            dataType: "json",
            data: { answerId: $('input[name=answerId]:checked').val() },
            success: function (data) {
                if (data != null)
                    printQuestion(data);
                else
                    window.location.href = '/Result';
            }
        });
    }
}
