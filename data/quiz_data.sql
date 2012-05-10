INSERT INTO Users  VALUES ('sahbi','sahbi','Sahbi','Jabnouni');
INSERT INTO Users  VALUES ('william','william','William','Free');
INSERT INTO Users  VALUES ('jackson','jackson','Jackson','Adam');
INSERT INTO Users  VALUES ('sam','sam','Sam','Ayoub');
INSERT INTO Users  VALUES ('tyler','tyler','Tyler','Millar');
INSERT INTO Users  VALUES ('ahmed','ahmed','Ahmed','Hamza');
INSERT INTO Users  VALUES ('leri','leri','Leri','Mon');
INSERT INTO Users  VALUES ('diana','diana','Diana','Ramirez');
INSERT INTO Users  VALUES ('sihem','sihem','Sihem','Romdhani');
INSERT INTO Users  VALUES ('sofi','sofi','Sofi','Curradi');


INSERT INTO Quizs(Description) VALUES  ('Are you smarter than a 5th Grader?');

INSERT INTO Questions (Description,QuizId) VALUES ('Polar bears eat penguins?',1);
INSERT INTO Answers (Description,IsCorrect,QuestionId)  VALUES ('True','False',1);
INSERT INTO Answers (Description,IsCorrect,QuestionId)  VALUES ('False','True',1);

INSERT INTO Questions (Description,QuizId) VALUES ('What nation has the longest border with the U.S.?',1);
INSERT INTO Answers (Description,IsCorrect,QuestionId)  VALUES ('Canada','True',2);
INSERT INTO Answers (Description,IsCorrect,QuestionId)  VALUES ('Alaska','False',2);
INSERT INTO Answers (Description,IsCorrect,QuestionId)  VALUES ('United Kingdom','False',2);
INSERT INTO Answers (Description,IsCorrect,QuestionId)  VALUES ('Mexico','False',2);
INSERT INTO Answers (Description,IsCorrect,QuestionId)  VALUES ('Russia','False',2);

INSERT INTO Questions (Description,QuizId) VALUES ('How many sides does a trapezoid have?',1);
INSERT INTO Answers (Description,IsCorrect,QuestionId)  VALUES ('5','False',3);
INSERT INTO Answers (Description,IsCorrect,QuestionId)  VALUES ('7','False',3);
INSERT INTO Answers (Description,IsCorrect,QuestionId)  VALUES ('8','False',3);
INSERT INTO Answers (Description,IsCorrect,QuestionId)  VALUES ('9','False',3);
INSERT INTO Answers (Description,IsCorrect,QuestionId)  VALUES ('4','True',3);

INSERT INTO Questions (Description,QuizId) VALUES ('What was the name of the ship the pilgrims first took to get to the U.S.?',1);
INSERT INTO Answers (Description,IsCorrect,QuestionId)  VALUES ('The Titanic','False',4);
INSERT INTO Answers (Description,IsCorrect,QuestionId)  VALUES ('Santa Maria','False',4);
INSERT INTO Answers (Description,IsCorrect,QuestionId)  VALUES ('The Mayflower','True',4);
INSERT INTO Answers (Description,IsCorrect,QuestionId)  VALUES ('El Nino','False',4);

INSERT INTO Questions (Description,QuizId) VALUES ('The ostrich is the fastest bird on land.',1);
INSERT INTO Answers (Description,IsCorrect,QuestionId)  VALUES ('True','True',5);
INSERT INTO Answers (Description,IsCorrect,QuestionId)  VALUES ('False','False',5);

INSERT INTO Questions (Description,QuizId) VALUES ('What is the largest south American country by area?',1);
INSERT INTO Answers (Description,IsCorrect,QuestionId)  VALUES ('Chile','False',6);
INSERT INTO Answers (Description,IsCorrect,QuestionId)  VALUES ('Brazil','True',6);
INSERT INTO Answers (Description,IsCorrect,QuestionId)  VALUES ('Argentina','False',6);

