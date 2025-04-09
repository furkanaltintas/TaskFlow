namespace Application.Features.Constants.AppUserConstants;

public static class AppUserConstant
{
    public static string UserIsLockedOutTimeSpan(double totalMinutes)
    {
        int minutes = (int)Math.Floor(totalMinutes);
        int seconds = (int)Math.Floor((totalMinutes - minutes) * 60);
        return $"Kullanıcı {minutes} dakika {seconds} saniye süreyle kilitlenmiştir";
    }
    public static string LoginSuccessful(string firstName) => $"Giriş başarılı. Hoş geldin {firstName}";


    public const string UserNotFound = "Sistemde böyle bir kullanıcı bulunmamaktadır";
    public const string UserNameOrPasswordWrong = "Kullanıcı adı veya şifre hatalı";
    public const string UserNotApproved = "Kullanıcı onaylanmamıştır";
    public const string UserIsLockedOut = "Kullanıcı kilitlenmiştir";
    public const string UserIsNotAllowed = "Kullanıcı onaylanmamıştır";
    public const string UserIsLockedOutNull = "Kullanıcı kilitlenmiştir";
}