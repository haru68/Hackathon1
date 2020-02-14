CREATE DATABASE Hackathon1;
USE Hackathon1;

CREATE TABLE Categories (
id INT PRIMARY KEY IDENTITY(1,1),
"name" VARCHAR(80) NOT NULL,
"description" TEXT);

CREATE TABLE Products (
id INT PRIMARY KEY IDENTITY (1,1),
price DECIMAL NOT NULL,
"name" VARCHAR(250) NOT NULL,
"description" TEXT,
hasTeeth BIT NOT NULL,
age INT NOT NULL,
hasOxygenBottle BIT NOT NULL,
isIncontinent BIT NOT NULL,
isHandicaped BIT,
category INT,
photo_path VARCHAR(250) ,
FOREIGN KEY (category) REFERENCES Categories(id)
);

INSERT INTO Products ("Name", Age, "Description", Price, hasTeeth, hasOxygenBottle, isIncontinent, isHandicaped)
VALUES
('Gerard', 84, 'Gerard is a very gourmand grandpa, hopefully he still has teeth so you will not have to mix his food everyday (we just do not know how long it is going to last...). One of his favourite topic of discussion is food. If you are a food lover you will talk easily for hours with him.', 4500, 1, 0, 0, 0),
('Oscar', 78, 'Oscar likes to go to the Opera, is very cultured, speaks 6 languages. He used to work for the american ambassy in different country.', 7290, 1, 0, 0, 0),
('Anton', 81, 'Anton is a musician, he plays accordion. He likes partying and drinks a lot of beer. He is always smiling and is an easygoing person, you will not regret spending some time with him. He is just sometimes incontinent, but usually only when he drinks too much beer.', 5990, 1, 0, 1, 0),
('Li', 69, 'Li was a soldier in Vietnam War, he lost his right arm during a battle. He has not had an easy life and hope to find a good family to finish his life surrounded by nice people.', 5550, 1, 0, 0, 1),
('Robert', 75, 'Robert is a retired cruise ship captain. He traveled all around the world during 40 years. He has a lot of strories to tell about his travels. But as he is now retired and on a wheel chair, he cannot travel anymore, so he is a little grumpy.', 4770, 1, 0, 0, 1),
('Bakir', 73, 'Bakir was a famous actor in Turkey, he likes to be the center of attention. He never smiles because he does not have any teeth left, but that does not mean he is an angry person.', 6800, 0, 0, 0, 0),
('Rati', 79, 'Rati likes to drive, indeed he used to work as a taxi driver. He will be happy to help you, like dropping kids to school or driving you around.', 3990, 1, 0, 0, 0),
('Henri', 67, 'Henri is a book writer. He still publishes some books. When he writes, he always has a cigarette between his lips. He has had some health issues, so now he needs an oxygen bottle to help him breath during the night.', 5190, 1, 1, 0, 0),
('Fernand', 71, 'Fernand used to be a magician. He is a kind person and will help you in your daily tasks thanks to the spells he learned.', 6300, 1, 0, 0, 0),
('Bradley', 72, 'Bradley is a special old man. He was part of a motar band. He really likes the speed and to feel the air on his tattooed cheeks. He likes rock n roll and talking about motorcycle, it is just a little bit hard to understand him when he does not put his denture.', 4250, 0, 0, 0, 0),
('Georgette', 89, 'Georgette is a super mamy, she has had 12 children who gave her 39 great children. She spoiled them as she could, but now she does not have much money and her great children never come to visit, that is why she puts herself on sale and look for an adoptive family.', 5000, 0, 0, 0, 0),
('Su-Wei', 76, 'Su-Wei is a Taiwanese grandma. She used to be a fish seller on the market. She knows how to attract people. I am sure she is going to attract you, and you are going to love her.', 4870, 1, 0, 0, 0),
('Rosa', 69, 'Rosa was a one of the first female football player, but she fell over the ball and hurt herself, since then she is paralized from her hips to her feet, but she never lost her willingness to live. After the accident she played wheelchair basketball. Unuseful to say that she is a fighter.', 4530, 1, 0, 0, 1),
('Aida', 70, 'Aida is a craftswoman. She used to create clothes and jewelery. She will be happy to participate with any craft workshops.', 5800, 1, 0, 0, 0),
('Gloria', 83, 'Gloria was a gospel singer. She still feels young and likes to hang out with younger people.', 6400, 1, 0, 0, 0),
('Denise', 68, 'Denise was a teacher. She really likes to read stories to children. She is just wears diapers because she became incontinent, but children do not need to know about it.', 4400, 1, 0, 1, 0),
('Paule', 95, 'Paule is an excellent cook, she used to work in the best restaurants of many european capitals. You will be happy to have her around when you cook. The only inconviniency is that she needs to carry her Oxygen bottle with her and as she is pretty old, it is very difficult for her to move.', 7100, 0, 1, 1, 0),
('Juliette', 67, 'Juliette is a farmer girl, she has always worked on her farm. Growing vegetables, fruits and taking care of her animals. But she cannot do this no more, she now is on a wheelchair because of her back pain.', 4290, 1, 0, 0, 1),
('Maylee', 90, 'Maylin has lost her husband last year, she needs some company. She does not have teeth anymore.', 4960, 0, 0, 0, 0),
('Mona', 89, 'Mona used to be a nurse. She likes to take care of people, but now it is time for that someone else take care of her. She needs her oxygen bottle to help her breath during the night.', 6590, 0, 1, 0, 0);

INSERT INTO Categories ("name", "description") 
VALUES
('Female', 'Enjoy Women TEAM'),
('Male', 'Enjoy Men TEAM');

UPDATE Products SET category = 1 WHERE id > 10;
UPDATE Products SET category = 2 WHERE id < 11;

UPDATE Products SET photo_path = '<img src="E:\Hackathon1\NancyPrototypr\bin\Debug\netcoreapp3.1\content\Gerard.png" alt="Gerard">' WHERE "name" = 'Gerard';
UPDATE Products SET photo_path = '<img src="E:\Hackathon1\NancyPrototypr\bin\Debug\netcoreapp3.1\content\Oscar.png" alt="Oscar">' WHERE "name" = 'Oscar';
UPDATE Products SET photo_path = '<img src="E:\Hackathon1\NancyPrototypr\bin\Debug\netcoreapp3.1\content\Anton.png" alt="Anton">' WHERE "name" = 'Anton';
UPDATE Products SET photo_path = '<img src="E:\Hackathon1\NancyPrototypr\bin\Debug\netcoreapp3.1\content\Li.png" alt="Li">' WHERE "name" = 'Li';
UPDATE Products SET photo_path = '<img src="E:\Hackathon1\NancyPrototypr\bin\Debug\netcoreapp3.1\content\Robert.png" alt="Robert">' WHERE "name" = 'Robert';
UPDATE Products SET photo_path = '<img src="E:\Hackathon1\NancyPrototypr\bin\Debug\netcoreapp3.1\content\Bakir.png" alt="Bakir">' WHERE "name" = 'Bakir';
UPDATE Products SET photo_path = '<img src="E:\Hackathon1\NancyPrototypr\bin\Debug\netcoreapp3.1\content\Rati.png" alt="Rati">' WHERE "name" = 'Rati';
UPDATE Products SET photo_path = '<img src="E:\Hackathon1\NancyPrototypr\bin\Debug\netcoreapp3.1\content\Henri.png" alt="Henri">' WHERE "name" = 'Henri';
UPDATE Products SET photo_path = '<img src="E:\Hackathon1\NancyPrototypr\bin\Debug\netcoreapp3.1\content\Fernand.png" alt="Fernand">' WHERE "name" = 'Fernand';
UPDATE Products SET photo_path = '<img src="E:\Hackathon1\NancyPrototypr\bin\Debug\netcoreapp3.1\content\Bradley.png" alt="Bradley">' WHERE "name" = 'Bradley';
UPDATE Products SET photo_path = '<img src="E:\Hackathon1\NancyPrototypr\bin\Debug\netcoreapp3.1\content\Georgette.png" alt="Georgette">' WHERE "name" = 'Georgette';
UPDATE Products SET photo_path = '<img src="E:\Hackathon1\NancyPrototypr\bin\Debug\netcoreapp3.1\content\Su-Wei.png" alt="Su-Wei">' WHERE "name" = 'Su-Wei';
UPDATE Products SET photo_path = '<img src="E:\Hackathon1\NancyPrototypr\bin\Debug\netcoreapp3.1\content\Rosa.png" alt="Rosa">' WHERE "name" = 'Rosa';
UPDATE Products SET photo_path = '<img src="E:\Hackathon1\NancyPrototypr\bin\Debug\netcoreapp3.1\content\Aida.png" alt="Aida">' WHERE "name" = 'Aida';
UPDATE Products SET photo_path = '<img src="E:\Hackathon1\NancyPrototypr\bin\Debug\netcoreapp3.1\content\Gloria.png" alt="Gloria">' WHERE "name" = 'Gloria';
UPDATE Products SET photo_path = '<img src="E:\Hackathon1\NancyPrototypr\bin\Debug\netcoreapp3.1\content\Denise.png" alt="Denise">' WHERE "name" = 'Denise';
UPDATE Products SET photo_path = '<img src="E:\Hackathon1\NancyPrototypr\bin\Debug\netcoreapp3.1\content\Paule.png" alt="Paule">' WHERE "name" = 'Paule';
UPDATE Products SET photo_path = '<img src="E:\Hackathon1\NancyPrototypr\bin\Debug\netcoreapp3.1\content\Juliette.png" alt="Juliette">' WHERE "name" = 'Juliette';
UPDATE Products SET photo_path = '<img src="E:\Hackathon1\NancyPrototypr\bin\Debug\netcoreapp3.1\content\Maylee.png" alt="Maylee">' WHERE "name" = 'Maylee';
UPDATE Products SET photo_path = '<img src="E:\Hackathon1\NancyPrototypr\bin\Debug\netcoreapp3.1\content\Mona.png" alt="Mona">' WHERE "name" = 'Mona';

SELECT * FROM Products;
SELECT * FROM Categories;




