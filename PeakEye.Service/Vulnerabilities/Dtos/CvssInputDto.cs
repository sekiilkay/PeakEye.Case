namespace PeakEye.Service.Vulnerabilities.Dtos
{
    public class CvssInputDto
    {
        public string AttackVector { get; set; }
        public string AttackComplexity { get; set; }
        public string PrivilegesRequired { get; set; }
        public string ConfidentialityImpact { get; set; }
        public string IntegrityImpact { get; set; }
        public string AvailabilityImpact { get; set; }
        public string UserInteraction { get; set; }
        public string Scope { get; set; }
    }

}
