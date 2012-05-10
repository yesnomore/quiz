google.load("visualization", "1", { packages: ["corechart"] });
$(document).ready(function () {
    printStat();
    printUser();
    printQuiz();
    printTotal();
    showResult();
 });

function showResult() {
    $.ajax({
        type: 'POST',
        url: '/Result/ShowResult',
        dataType: "json",
        success: function (data) {
            printResult(data);
        }
    });
}
function printResult(data) {
    $('#result').empty();
    $('#result').append('<div><strong>Your Report:</strong></div>');
    $.each(data, function (i) {
        $('#result').append('<div class="title">' + data[i].Description + '</div>');
        var answers = data[i].UserAnswers;
        var chars = new Array("A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L");
        $.each(answers, function (j) {
            var html = '<div class="answer"><strong>' + chars[j] + '</strong> ';
            html = html + answers[j].Description;
            if (answers[j].Message != null) {
                html = html + answers[j].Message;
                if (answers[j].IsCorrect == true)
                    html = html + '<image src="../../images/ok.png"/>';
                if (answers[j].IsCorrect == false && answers[j].IsUserCorrect == true)
                    html = html + '<image src="../../images/ko.png"/>';
                html = html + '</div>';
            }
            else {
                html = html + '</div>';
            }
            $('#result').append(html);
        });
    });    
 }
 function printUser() {
     $.ajax({
         type: 'POST',
         url: '/Home/ShowUser',
         dataType: "json",
         success: function (data) {
             $('#user').append('<strong>Welcome:</strong> ' + data.FirstName + '   ' + data.LastName);
         }
     });
 }
 function printQuiz() {
     $.ajax({
         type: 'POST',
         url: '/Quiz/ShowQuiz',
         dataType: "json",
         success: function (data) {
             $('#quiz').append('<strong>Quiz:</strong> ' + data.Description);
         }
     });
 }
 function printTotal() {
     $.ajax({
         type: 'POST',
         url: '/Result/ShowTotal',
         dataType: "json",
         success: function (data) {
             $('#total').append('<strong>Your result:</strong> ' + data.CorrectAnswers + ' correct answers');
         }
     });
 }

function printStat() {
    var url = "Result/ShowStat";
    $.getJSON(url, function (response) {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'User');
        data.addColumn('number', 'Correct Answers');
        for (var i = 0; i < response.length; i++) {
            var row = new Array();
            row[0] = response[i].Name;
            row[1] = parseInt(response[i].Value);
            data.addRow(row);
        }
        var chart = new google.visualization.ColumnChart(document.getElementById('stat'));
        chart.draw(data, { width: 800, height: 300, title: 'Top 10', lineWidth: 4, pointSize: 6,
            hAxis: { title: 'User', titleTextStyle: { color: 'red'} }
        });
    }
    );
}

