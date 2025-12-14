namespace DesignPrac
{ 
    public class Program 
    { 
        public static void Main(string[] args) 
        { 
            DesignPracAbstractHierarchicalPattern.IMultipleFileMergeTemplate mergeTemplate = DesignPracAbstractHierarchicalPattern.MultipleFileMergeTemplateFactory.CreateMultipleFileMergeTemplate("CITI_CHAPS");
            mergeTemplate.Execute();
            mergeTemplate = DesignPracAbstractHierarchicalPattern.MultipleFileMergeTemplateFactory.CreateMultipleFileMergeTemplate("HSBC_CHAPS");
            mergeTemplate.Execute();


            // DesignPracCompositionalStrategy.IMultipleFileMergeTemplate<DesignPracCompositionalStrategy.IMergeBehaviourStrategy> mergeTemplate = DesignPracCompositionalStrategy.MultipleFileMergeTemplateFactory.CreateMultipleFileMergeTemplate("CITI_CHAPS");
            // mergeTemplate.Execute();
            // mergeTemplate = DesignPracCompositionalStrategy.MultipleFileMergeTemplateFactory.CreateMultipleFileMergeTemplate("HSBC_CHAPS");
            // mergeTemplate.Execute();
        } 
    }
}