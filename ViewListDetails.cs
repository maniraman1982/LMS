using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourierServices.Models
{
    public class ViewListDetails
    {
        public int ID { get; set; }
        public string TestName { get; set; }
        public string TestCode { get; set; }
        public string TestCodeRef { get; set; }
        public double TestPriority { get; set; }
        public double ProfilePriority { get; set; }
        public double SubProfilePriority { get; set; }
        public double DeptPriority { get; set; }
        public string AcceptAll { get; set; }
        public string RejectAll { get; set; }
        public string Accept { get; set; }
        public string Reject { get; set; }
        public string MrdNo { get; set; }
        public int TestType { get; set; }
        public string DepartmentName { get; set; }
        public Boolean NumericOrText { get; set; }
        public int Priority { get; set; }
        public string Methodology { get; set; }
        public string SampleContainer { get; set; }
        public string UnitMeasurementNumeric { get; set; }
        public string UnitMesurementFreeText { get; set; }
        public string TableRequiredPrint { get; set; }
        public string DefaultValues { get; set; }
        public string GenderMale { get; set; }
        public string GenderFemale { get; set; }
        public string Pregnancyrefrange { get; set; }
        public string Multiplecomponents { get; set; }
        public string AdditionalFixedComments { get; set; }
        public string LowerCriticalValue { get; set; }
        public string UpperCriticalValue { get; set; }
        public string OtherCriticalReport { get; set; }
        public string AgewiseCriticalValue { get; set; }
        public string AgewiseReferenceRange { get; set; }
        public string units { get; set; }
        //Region for multi
        public int MultiComponentId { get; set; }       
        public string MultiElementName { get; set; }
        public string MultiCalculation { get; set; }
        public string MultiResult { get; set; }
        public string MultiNotes { get; set; }
        public string MultiComments { get; set; }
        public string MultiActualValue { get; set; }
        public string MultiNormalValues { get; set; }
        public string MultiUnits { get; set; }
        public string MultiDisplayValue { get; set; }
        // region for ageRef
        public string AgewiseNormalValue { get; set; }
        public string AgewiseFreeText { get; set; }
        public string AgewiseDispalyvalue { get; set; }
        // Region for calc
        public string Calcunits { get; set; }
        public string splcalculation { get; set; }
        public string formulaLabel { get; set; }
 
        public DateTime MultiCreateDate { get; set; }
        public int RegID { get; set; }
        public int Status { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public string Result { get; set; }
        public string Comments { get; set; }

    }
}