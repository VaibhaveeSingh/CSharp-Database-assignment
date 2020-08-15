CREATE PROCEDURE UpdateRecord
@title varchar(50),
@artistname varchar (20),
@sno int
As
BEGIN  
            UPDATE records
            SET    Title = @title,  
                   artistName = @artistname
                  WHERE sNo = @sno
                   
              
        END  