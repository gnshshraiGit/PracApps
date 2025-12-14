using System;

namespace DesignPracAbstractHierarchicalPattern
{ 
    public class AbstractHierarchicalPatternProgram
    { 
        // public static void Main(string[] args) 
        // { 
        //     IMultipleFileMergeTemplate mergeTemplate = MultipleFileMergeTemplateFactory.CreateMultipleFileMergeTemplate("CITI_CHAPS");
        //     mergeTemplate.Execute();
        //     mergeTemplate = MultipleFileMergeTemplateFactory.CreateMultipleFileMergeTemplate("HSBC_CHAPS");
        //     mergeTemplate.Execute();
        // } 
    }

    public static class MultipleFileMergeTemplateFactory
    {
        public static IMultipleFileMergeTemplate CreateMultipleFileMergeTemplate(string mergeType)
        {
            switch (mergeType)
            {
                case "CITI_CHAPS":
                    return new CitiChapsFileMergeTemplate();
                case "HSBC_CHAPS":
                    return new HsbcChapsFileMergeTemplate();
                default:
                    throw new NotSupportedException($"Merge type {mergeType} is not supported.");
            }
        }
    }

    public interface IMultipleFileMergeTemplate
    {
        bool Execute();
        void ShowStartegy();
        string StartMerge(string x, string y);
        string ReportMerge(string mergedData);
    }

    public class CitiChapsFileMergeTemplate : TwoCsvFileMergeTemplate
    {
        public override string StartMerge(string s1, string s2)
        {
            // CSV specific merge logic
            return "CitiChaps CSV Data" + s1 + s2;
        }

        public override string ReportMerge(string mergedData)
        {
            // CSV specific report logic
            return $"CitiChaps CSV Merge Report: {mergedData}";
        }
    }

    public class HsbcChapsFileMergeTemplate : TwoCsvFileMergeTemplate
    {
        public override string StartMerge(string s1, string s2)
        {
            // CSV specific merge logic
            return "HsbcChaps CSV Data" + s1 + s2;
        }

        public override string ReportMerge(string mergedData)
        {
            // CSV specific report logic
            return $"HsbcChaps CSV Merge Report: {mergedData}";
        }
    }

    public abstract class TwoCsvFileMergeTemplate  : IMultipleFileMergeTemplate
    {
        public abstract string StartMerge(string s1, string s2);
       
        public abstract string ReportMerge(string mergedData);

        public virtual void ShowStartegy()
        {
            Console.WriteLine($"Using strategy: {this.GetType().Name}");
        }

        public virtual bool Execute()
        {
            string file1Data = "File1Data";
            string file2Data = "File2Data";
            ShowStartegy();
            string mergedData = StartMerge(file1Data, file2Data);
            string report = ReportMerge(mergedData);

            Console.WriteLine(report);
            return true;
        }
    }
}