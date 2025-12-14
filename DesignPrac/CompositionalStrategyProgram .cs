using System;

namespace DesignPracCompositionalStrategy
{ 
    public class CompositionalStrategyProgram 
    { 
        // public static void Main(string[] args) 
        // { 
        //     IMultipleFileMergeTemplate<IMergeBehaviourStrategy> mergeTemplate = MultipleFileMergeTemplateFactory.CreateMultipleFileMergeTemplate("CITI_CHAPS");
        //     mergeTemplate.Execute();
        //     mergeTemplate = MultipleFileMergeTemplateFactory.CreateMultipleFileMergeTemplate("HSBC_CHAPS");
        //     mergeTemplate.Execute();
        // } 
    }

    public static class MultipleFileMergeTemplateFactory
    {
        public static IMultipleFileMergeTemplate<IMergeBehaviourStrategy> CreateMultipleFileMergeTemplate(string mergeType)
        {
            switch (mergeType)
            {
                case "CITI_CHAPS":
                    return new TwoCsvFileMergeTemplate<CitiChapsMergeBehaviourStrategy>();
                case "HSBC_CHAPS":
                    return new TwoCsvFileMergeTemplate<HsbcChapsMergeBehaviourStrategy>();
                default:
                    throw new NotSupportedException($"Merge type {mergeType} is not supported.");
            }
        }
    }

    public interface IMergeBehaviourStrategy
    {
        string StartMerge(string x, string y);
        string ReportMerge(string mergedData);
    }

    public interface IMultipleFileMergeTemplate<out T> where T : IMergeBehaviourStrategy
    {
        bool Execute();
        void ShowStartegy();
    }

    public class CitiChapsMergeBehaviourStrategy : IMergeBehaviourStrategy
    {
        public string StartMerge(string s1, string s2)
        {
            // CSV specific merge logic
            return "CitiChaps Merged CSV Data" + s1 + s2;
        }

        public string ReportMerge(string mergedData)
        {
            // CSV specific report logic
            return $"CitiChaps CSV Merge Report: {mergedData}";
        }
    }

    public class HsbcChapsMergeBehaviourStrategy : IMergeBehaviourStrategy
    {
        public string StartMerge(string s1, string s2)
        {
            // CSV specific merge logic
            return "HsbcChaps Merged CSV Data" + s1 + s2;
        }

        public string ReportMerge(string mergedData)
        {
            // CSV specific report logic
            return $"HsbcChaps CSV Merge Report: {mergedData}";
        }
    }

    public class TwoCsvFileMergeTemplate<T>  : IMultipleFileMergeTemplate<T> where T : IMergeBehaviourStrategy, new()
    {
        private readonly T _mergeStrategy;

        public TwoCsvFileMergeTemplate(T mergeStrategy)
        {
            // Use the null-coalescing operator ??
            _mergeStrategy = mergeStrategy;
        }

        public TwoCsvFileMergeTemplate()
        {
            // Use the null-coalescing operator ??
            _mergeStrategy = new T();
        }

        public void ShowStartegy()
        {
            Console.WriteLine($"Using strategy: {_mergeStrategy.GetType().Name}");
        }

        public bool Execute()
        {
            string file1Data = "File1Data";
            string file2Data = "File2Data";
            ShowStartegy();
            string mergedData = _mergeStrategy.StartMerge(file1Data, file2Data);
            string report = _mergeStrategy.ReportMerge(mergedData);

            Console.WriteLine(report);
            return true;
        }
    }
}