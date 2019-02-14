using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using static System.Console;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPdfFileLife
{
    class Program
    {
        private static PdfChecker _PdfChecker;
        static void Main(string[] args)
        {
            _PdfChecker = new PdfChecker();
            _PdfChecker.getPdfFilesFromDirectory();
        }

        
    }

    public class PdfChecker
    {
        private string strDirectory;
        private List<string> lsDirectories;
        private List<String> lsPDF_FilesPaths;

        /// <summary>
        /// Constructor.
        /// </summary>
        public PdfChecker()
        {
            strDirectory = "";
            lsDirectories = new List<string>();
            lsPDF_FilesPaths = new List<string>();
        }

        /// <summary>
        /// Tool info.
        /// </summary>
        public void ProgramInfo()
        {
           WriteLine("\t\t\t\tPDF Sweeper");
           WriteLine("\t\tPDF Sweeper developed to help users cleaning up thier computers from corrupted PDF");
           WriteLine("\t\tto save some more space.");
           WriteLine("\t\t\tDeveloped By: Mohamed Abdelaziz");
           WriteLine("\t\t\tE-mail: mohamedsaleh1984@hotmail.com\n\n");
        }


        /// <summary>
        /// Return list of PDF files from given directory and sub directories.
        /// </summary>
        /// <param name="strDir"></param>
        /// <returns></returns>
        public List<String> getPdfFilesFromDirectory()
        {
            lsPDF_FilesPaths = new List<string>();
            lsPDF_FilesPaths = Directory.GetFiles(strDirectory, "*.pdf|*.PDF", SearchOption.AllDirectories).ToList();
          
            return lsPDF_FilesPaths;
        }

        /// <summary>
        /// Return list of PDF files from given directories and sub directories.
        /// </summary>
        /// <param name="lsDirectories">Directory List</param>
        /// <returns></returns>
        public List<String> getPdfFilesFromDirectory(List<String> lsDirectories)
        {
            lsPDF_FilesPaths = new List<string>();
            List<String> lsPDF_All_FilesPaths = new List<string>();
            foreach (var strDir in lsDirectories)
            {
                lsPDF_FilesPaths =  Directory.GetFiles(strDir, "*.pdf|*.PDF", SearchOption.AllDirectories).ToList();
                foreach (var item in lsPDF_FilesPaths)
                {
                    lsPDF_All_FilesPaths.Add(item);
                }
            }
            return lsPDF_All_FilesPaths;
        }

        /// <summary>
        /// Check if given pdf file is Corrupted or not.
        /// </summary>
        /// <param name="filePath">PDF file Path</param>
        /// <returns>true otherwise; false</returns>
        public  bool isPDFcorrupted(string filePath)
        {
            bool bResult = false;
            PdfReader reader = null;
            try
            {
                reader = new PdfReader(filePath);
                reader.Close();

            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("PDF header signature not found."))
                {
                    bResult = true;
                }
            }
            return bResult;
        }
    }
}
