namespace DesignPrac
{ 
    public class Program 
    { 
        public static void Main(string[] args) 
        { 
            DesignPracCompositionalStrategy.IMultipleFileMergeTemplate<DesignPracCompositionalStrategy.IMergeBehaviourStrategy> mergeTemplateP1 = DesignPracCompositionalStrategy.MultipleFileMergeTemplateFactory.CreateMultipleFileMergeTemplate("CITI_CHAPS");
            mergeTemplateP1.Execute();
            mergeTemplateP1 = DesignPracCompositionalStrategy.MultipleFileMergeTemplateFactory.CreateMultipleFileMergeTemplate("HSBC_CHAPS");
            mergeTemplateP1.Execute();


            DesignPracAbstractHierarchicalPattern.IMultipleFileMergeTemplate mergeTemplateP2 = DesignPracAbstractHierarchicalPattern.MultipleFileMergeTemplateFactory.CreateMultipleFileMergeTemplate("CITI_CHAPS");
            mergeTemplateP2.Execute();
            mergeTemplateP2 = DesignPracAbstractHierarchicalPattern.MultipleFileMergeTemplateFactory.CreateMultipleFileMergeTemplate("HSBC_CHAPS");
            mergeTemplateP2.Execute();

        } 
    }
}