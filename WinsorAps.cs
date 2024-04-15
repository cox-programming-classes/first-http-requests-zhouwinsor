namespace CS_First_HTTP_Client;

public readonly record struct Login(string email, string password);

public readonly record struct ErrorResponse(string type, string error);

public readonly record struct AuthResponse(string userId, string jwt, DateTime expires, string refreshToken);

public readonly record struct UserInfo(string id, 
    string firstName, string nickname, string lastName, string email, StudentInfo? studentInfo = null);

public readonly record struct StudentInfo(int gradYear, string className, AdvisorInfo? advisor);

public readonly record struct AdvisorInfo(string id, string firstName, string lastName, string email);

public readonly record struct Schedule(string sectionId, string courseId, string primaryTeacherId, string[] 
    teachers, string[] students, string termId, string room, string block, string blockId, string displayName, string schoolLevel);

public readonly record struct CycleDay(DateOnly date, String cycleDay);

public readonly record struct Assessment(string id, string type, string summary, string description, 
    DateOnly start, DateOnly end, bool allDay, string[] affectedClasses, bool passUsed, bool passAvailable);

public readonly record struct Passes(Assessment assessment, StudentInfo student);





    