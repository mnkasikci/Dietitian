namespace Dietitian.TextModels
{
    public enum DietType
    {
        Akdeniz = 1,
        GlutenFree = 2,
        DenizUrunleri = 3,
        YesilliklerDunyasi = 4
    }

    public enum Disease
    {
        Obese = 1,
        Colyak = 2,
        Seker = 3
    }
    public enum MainMenuEntry
    {
        AddPatient = 1,
        ListPatients = 2,
        ChangePatientDiet = 3,
        GetReport = 4,
        Exit = 5
    }
    public enum ReportOrderEntry
    {
        PatientInfoFirst = 1,
        DietInfoFirst = 2
    }
    public enum ReportTypeEntry
    {
        Json = 1,
        HTML= 2
    }
    public static class MenuTexts
    {
        public const string Diets = "Lutfen diyet turunu giriniz\n"+ 
            "1 - Akdeniz \n" +
            "2 - GlutenFree\n" +
            "3 - DenizUrunleri\n" +
            "4 - YesilliklerDunyasi\n";

        public const string Diseases = "Lutfen hastalik adini giriniz\n" +
            "1 - Obez \n" +
            "2 - Colyak\n" +
            "3 - Seker\n";

        public const string MainMenu =
            "---------Ana Menu-------\n"+
            "1 - Yeni Hasta Ekle\n" +
            "2 - Hastalari Listele\n" +
            "3 - Hastanin diyetini degistir\n" +
            "4 - Hasta raporu al\n" +
            "5 - Programdan cik\n";
        public const string ReportOrder = "Rapor siralamasi nasil olsun?\n" +
            "1 - Once Hasta Bilgiileri\n" +
            "2 - Once Diyet Bilgileri\n";

        public const string ReportFileType = "Rapor dosyasinin turu ne olsun?\n" +
            "1 - Json\n" +
            "2 - HTML\n";
    }
}
