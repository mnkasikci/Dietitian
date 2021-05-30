using Dietitian.Models.Diets;
using Dietitian.Models.Diseases;
using Dietitian.Models.PersonModels;
using Dietitian.Reporters;
using Dietitian.TextModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dietitian
{
    class Program
    {
        public static List<Patient> hastalar = new();
        public static DietExpert Dietitian;
        static void Main(string[] args)
        {
            GetDietitianInfo();
            MainMenu();
        }

        private static void GetDietitianInfo()
        {
            Console.Write("Lutfen diyetisyenin adini giriniz: ");
            string name = Console.ReadLine();
            Dietitian = new(name);
        }

        private static void MainMenu()
        {
            bool exit = false;
            while (true)
            {
                Console.Write(MenuTexts.MainMenu);
                MainMenuEntry entry = GetEntry<MainMenuEntry>();
                switch (entry)
                {
                    case MainMenuEntry.AddPatient:
                        AddPatient();
                        break;
                    case MainMenuEntry.ChangePatientDiet:
                        ChangePatientDiet();
                        break;
                    case MainMenuEntry.GetReport:
                        GetReport();
                        break;
                    case MainMenuEntry.Exit:
                        exit = true;
                        break;
                    case MainMenuEntry.ListPatients:
                        ListPatients();
                        break;
                }
                if (exit) break;

            }
        }

        private static void ListPatients()
        {
            Console.WriteLine("{0,5}{1,20}{2,20}{3,20}", "Ind","Hasta Adi","Hastaligi","Diyeti");
            for (int i = 0;i<hastalar.Count;i++)
            {
                var h = hastalar[i];
                Console.WriteLine("{0,5}{1,20}{2,20}{3,20}",
                    i + 1,
                    h.HastaAdi,
                    h.Hastalik.GetDiseaseName(),
                    h.Hastalik.Diyet.GetDietName());
            }
        }

        private static T GetEntry<T>() where T : Enum
        {
            Type x = typeof(T);
            int limit = Enum.GetValues(x).Length;
            while (true)
            {
                var c = Console.ReadLine();
                int entry = -1;
                int.TryParse(c, out entry);
                if (entry > 0 && entry <= limit) return (T)(object)entry;
                Console.WriteLine("Lutfen gecerli bir giris yapiniz");
            }
        }

        private static void AddPatient()
        {
            //kisisel bilgiler
            string hastaAdi;
            string dogumYili;
            Console.Write("Hasta adini giriniz: ");
            hastaAdi = Console.ReadLine();
            Console.Write("Hastaninh yasini giriniz: ");
            dogumYili = Console.ReadLine();

            HastalikAbstraction ha = PickDisease();

            DiyetImplementor d = PickDiet();
            ha.Diyet = d;

            Patient p = new Patient(hastaAdi,dogumYili,ha);
            hastalar.Add(p);
        }

        private static DiyetImplementor PickDiet()
        {
            DiyetImplementor diyetImplementor;
            Console.WriteLine(MenuTexts.Diets);
            DietType dietsEnum = GetEntry<DietType>();
            switch (dietsEnum)
            {
                case DietType.Akdeniz:
                    diyetImplementor = new AkdenizDiyeti();
                    break;
                case DietType.GlutenFree:
                    diyetImplementor = new GlutenFree();
                    break;
                case DietType.DenizUrunleri:
                    diyetImplementor = new Denizurunlerı();
                    break;
                case DietType.YesilliklerDunyasi:
                    diyetImplementor = new YesilliklerDunyasi();
                    break;
                default:
                    throw new Exception("Gecersiz menu secimi");
            }
            return diyetImplementor;
        }

        private static HastalikAbstraction PickDisease()
        {
            HastalikAbstraction ha;
            Console.WriteLine(MenuTexts.Diseases);
            Disease diseaseEnum = GetEntry<Disease>();
            switch (diseaseEnum)
            {
                case Disease.Obese:
                    ha = new Obez();
                    break;
                case Disease.Colyak:
                    ha = new Colyak();
                    break;
                case Disease.Seker:
                    ha = new Seker();
                    break;
                default:
                    throw new Exception("Gecersiz menu secimi");
            }
            return ha;
        }

        private static void ChangePatientDiet()
        {
            int index = AskUserIndex();
            if (index == -1) return;
            var d = PickDiet();
            hastalar[index].Hastalik.Diyet = d;
        }
        private static int AskUserIndex ()
        {
            int index;
            bool succes = false;
            do
            {
                Console.WriteLine("Lutfen hastanin indeksini giriniz (bilmiyorsaniz -1 girip cikin ve ana menuden listeletin): ");
                string entry = Console.ReadLine();
                succes = int.TryParse(entry, out index);
                if(!succes)
                {
                    Console.WriteLine("Gecersiz giris");
                    continue;
                }

                if (index == -1) return -1;

                index--; // user friendly index should start from 1 whereas list index starts from 0
                if (index >= hastalar.Count || index < 0)
                {
                    Console.WriteLine("Gecersiz indeks");
                    continue;
                }
                
                return index;
            } while (true);
            
        }
        private static void GetReport()
        {
            string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string extension; 
            
            int index = AskUserIndex();
            if (index == -1) return;

            //Deciding on Json v. Html & creating builder class accordingly
            Console.WriteLine(MenuTexts.ReportFileType);
            ReportTypeEntry reportTypeEntry = GetEntry<ReportTypeEntry>();

            ReportBuilderBase reportBuilder;
            switch (reportTypeEntry)
            {
                case ReportTypeEntry.HTML:
                    reportBuilder = new HtmlReportBuilder(hastalar[index], Dietitian);
                    extension = ".html";
                    break;
                case ReportTypeEntry.Json:
                    reportBuilder = new JsonReportBuilder(hastalar[index], Dietitian);
                    extension = ".json";
                    break;
                default: throw new Exception("Gecersiz menu secimi");
            }
            string fileName = Path.Combine(desktopFolder, "Rapor" + extension);

            //Deciding on report order. That enum will be used in the method.
            Console.WriteLine(MenuTexts.ReportOrder);
            ReportOrderEntry reportOrder = GetEntry<ReportOrderEntry>();
            ReportManager rm = new ReportManager(reportBuilder);

            string content = reportOrder == ReportOrderEntry.DietInfoFirst ? rm.BuildDietInfoFirst() : rm.BuildPersonalInfoFirst();

            File.WriteAllText(fileName, content);

        }
    }
}
