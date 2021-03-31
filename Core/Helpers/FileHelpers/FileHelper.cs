using Core.Constanst;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Core.Helpers.FileHelpers
{
    public class FileHelper
    {
        //static string directory = directory.getcurrentdirectory() + @"\wwwroot\";
        //static string path = @"images\";
        //public static ıdataresult<string> writefilepath(ıformfile formfile, string path)
        //{
        //    var createfile = filenamecreator(formfile, path);
        //    var fullpath = path.combine(path, createfile.filename);
        //    try
        //    {
        //        var sourcepath = path.gettempfilename();
        //        if (formfile.length > 0)
        //            using (var stream = new filestream(sourcepath, filemode.create))
        //                formfile.copyto(stream);

        //        if (!directory.exists(path))
        //        {
        //            directory.createdirectory(path);
        //        }

        //        file.move(sourcepath, fullpath);
        //    }
        //    catch (exception e)
        //    {

        //        return new errordataresult<string>(e.message);
        //    }
        //    return new successdataresult<string>(createfile.path,messages.filetosave);
        //}

        private static (string fileName, string path) FileNameCreator(IFormFile formFile)
        {
            var fileName = Guid.NewGuid().ToString("N") + GetFileExtension(formFile);
            string pathToSave = Environment.CurrentDirectory + @"\wwwroot\images";

            string result = $@"{pathToSave}\{fileName}";

            return (result, $"\\images\\{fileName}");
            
        }

        private static string GetFileExtension(IFormFile formFile)
        {
            return new FileInfo(formFile.FileName).Extension;
        }

        public static string Add(IFormFile file)
        {
            var result = FileNameCreator(file);
            try
            {
                var sourcePath = Path.GetTempFileName();
                if (file.Length > 0)
                    using (var stream = new FileStream(sourcePath, FileMode.Create))
                        file.CopyTo(stream);
                File.Move(sourcePath, result.fileName);
            }
            catch (Exception exception)
            {
                return (exception.Message);
            }
            return (result.path);

        }
        public static string Update(IFormFile formFile, string oldImagePath)
        {
            var result = FileNameCreator(formFile);
            try
            {
                if (oldImagePath.Length > 0)
                {
                    using (var stream = new FileStream(result.fileName, FileMode.Create))
                    {
                        formFile.CopyTo(stream);
                    }
                }
                File.Delete(oldImagePath);
            }
            catch (Exception exception)
            {
                return (exception.Message);
            }
            return (result.path);
        }
        public static IResult Delete(string path)
        {
            try
            {
                //if (File.Exists(directory + path.Replace("/", "\\"))
                //&& Path.GetFileName(path) != "defaultlogo.jpg")
                //{
                //    File.Delete(directory + path.Replace("/", "\\"));
                File.Delete(path);
                //}
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

    }
}
