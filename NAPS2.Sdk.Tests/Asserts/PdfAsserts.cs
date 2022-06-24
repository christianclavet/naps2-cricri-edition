﻿using NAPS2.ImportExport.Pdf;
using PdfSharp.Pdf.IO;
using Xunit;

namespace NAPS2.Sdk.Tests.Asserts;

using PdfAValidator = PdfAValidator.PdfAValidator;
    
public static class PdfAsserts
{
    private static readonly Lazy<PdfAValidator> LazyPdfAValidator = new Lazy<PdfAValidator>(() => new PdfAValidator());
        
    public static void AssertPageCount(int count, string filePath)
    {
        var doc = PdfReader.Open(filePath, PdfDocumentOpenMode.InformationOnly);
        Assert.Equal(count, doc.PageCount);
    }

    public static void AssertCompliant(string profile, string filePath)
    {
        var report = LazyPdfAValidator.Value.ValidateWithDetailedReport(filePath);
        Assert.True(report.Jobs.Job.ValidationReport.IsCompliant);
        Assert.StartsWith($"{profile} ", report.Jobs.Job.ValidationReport.ProfileName);
    }

    public static void AssertContainsText(string text, string filePath)
    {
        bool containsText = false;
        foreach (var pageText in new PdfiumPdfReader().ReadTextByPage(filePath))
        {
            if (pageText.Contains(text))
            {
                containsText = true;
            }
        }
        Assert.True(containsText);
    }
}