using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//N56 - HT1

//- console project yarating, build fayllar folderi ichida Storage nomli folder yarating
//- Storage folder ichida User va userId si bilan folder oching, masalan 

//Storage/User/D426EE1A-486A-4F76-98D4-29CA8B176F76

//- bu bizda shu bitta userning fayllari turadigan joy hisoblanadi
//- unda Profile va Resume nomli folderlar ochib, ichiga har xil fallar joylang

//asosiy tasklar
//- bizga bir nechta userlar kerak bo'ladi, o'rtacha 5-10 ta user uchun folder oching
//- folderlar ichiga har xil faylllardan joylang, masalan Profile folder ichiga pdf yoki word fayllar
//- dastur run bo'lganida barcha Profile folder ichidagi rasm bo'lmagan ( extension rasm bo'lmagan )
//fayllarni va rasm bo'lganlari orasidan 60 KB dan kam bo'lganlarini o'chirib yuboring
//- Resume larni ichidan esa dokument bo'lmagan ( extension document bo'magan ) fayllarni console ga chiqaring 
//- bunda kerak bo'ladigan DirectoryService va FileService ni CleanUpService ichida ishlating,
//    bu servicelar vazifasi tuzilishi va ishlashi servicelar nomidan ham ma'lum


namespace WorkingFiles_N56_HT;
public class ConsoleApp
{
    public static void Execute()
    {
        var folderName = "Storage";
        var absolutePath = Directory.GetCurrentDirectory();

        var folderAbsolutePath = Path.Combine(absolutePath, folderName);

        Directory.CreateDirectory(folderName);

        var fileName = "User";
        var fileName1 = "User1";
        var fileName2 = "User2";
        var fileName3 = "User3";
        var fileName4 = "User4";
        var fileName5 = "User5";


        var folderAbsolutePath2 = Path.Combine(folderAbsolutePath, fileName1);
        var folderAbsolutePath3 = Path.Combine(folderAbsolutePath, fileName2);
        var folderAbsolutePath4 = Path.Combine(folderAbsolutePath, fileName3);
        var folderAbsolutePath5 = Path.Combine(folderAbsolutePath, fileName4);
        var folderAbsolutePath6 = Path.Combine(folderAbsolutePath, fileName5);

        Directory.CreateDirectory(folderAbsolutePath2);
        Directory.CreateDirectory(folderAbsolutePath3);
        Directory.CreateDirectory(folderAbsolutePath4);
        Directory.CreateDirectory(folderAbsolutePath5);
        Directory.CreateDirectory(folderAbsolutePath6);

        var folderOfFileName1 = "Profile";
        var folderOfFileName2 = "Resume";

        var createdFolderOfFile = Path.Combine(folderAbsolutePath2, folderOfFileName1);
        var createdFolderOfFile1 = Path.Combine(folderAbsolutePath3, folderOfFileName1);
        var createdFolderOfFile2 = Path.Combine(folderAbsolutePath4, folderOfFileName1);
        var createdFolderOfFile3 = Path.Combine(folderAbsolutePath5, folderOfFileName1);
        var createdFolderOfFile4 = Path.Combine(folderAbsolutePath6, folderOfFileName1);

        Directory.CreateDirectory(createdFolderOfFile);
        Directory.CreateDirectory(createdFolderOfFile1);
        Directory.CreateDirectory(createdFolderOfFile2);
        Directory.CreateDirectory(createdFolderOfFile3);
        Directory.CreateDirectory(createdFolderOfFile4);

        var createdResume = Path.Combine(createdFolderOfFile, folderOfFileName2);
        var createdResume1 = Path.Combine(createdFolderOfFile1, folderOfFileName2);
        var createdResume2 = Path.Combine(createdFolderOfFile2, folderOfFileName2);
        var createdResume3 = Path.Combine(createdFolderOfFile3, folderOfFileName2);
        var createdResume4 = Path.Combine(createdFolderOfFile4, folderOfFileName2);

        Directory.CreateDirectory(createdResume);
        Directory.CreateDirectory(createdResume1);
        Directory.CreateDirectory(createdResume2);
        Directory.CreateDirectory(createdResume3);
        Directory.CreateDirectory(createdResume4);


        Console.WriteLine("Created successfully");

    }
}


