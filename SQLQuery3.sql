
CREATE PROCEDURE insertRecord
@title varchar (50), 
@artistName varchar(20)
AS  
BEGIN
INSERT INTO records  (Title,artistName)  
            VALUES     (@title,@artistName)  
 END  

 CREATE PROCEDURE deleteRecord
@sno int
AS  
BEGIN
 DELETE FROM records WHERE @sno
END  