using AppWorldAgent.Infrastructure.Models.Result;

namespace AppWorldAgent.Services.Entity
{
    public class UserProfileModel : ResultModel
    {
        public UserProfileModel()
        {
            Data = new ProfileModel();
        }

        public ProfileModel Data { get; set; }
    }

    public class ProfileModel
    {
        #region Properties
        /// <summary>
        /// Gets or sets CountryId
        /// </summary>
        //public string CountryId { get; set; }
        /// <summary>
        /// Gets or sets CountryResidenceId
        /// </summary>
        //public string CountryResidenceId { get; set; }
        /// <summary>
        /// Gets or sets FirstName
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets LastName
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets sex
        /// </summary>
        //public string Sex { get; set; }
        /// <summary>
        /// Gets or sets BirthDate
        /// </summary>
        //public DateTime BirthDate { get; set; }
        /// <summary>
        /// Gets or sets IdentificationDocument
        /// </summary>
        //public string IdentificationDocument { get; set; }
        /// <summary>
        /// Gets or sets IdentificationDocumentNumber
        /// </summary>
        //public string IdentificationDocumentNumber { get; set; }
        /// <summary>
        /// Gets or sets PassportNumber
        /// </summary>
        //public string PassportNumber { get; set; }
        /// <summary>
        /// Gets or sets PhoneNumber
        /// </summary>
        //public string PhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets Email
        /// </summary>
        //public string Email { get; set; }
        /// <summary>
        /// Gets or sets BlockingReason
        /// </summary>
        //public string BlockingReason { get; set; }
        ///// <summary>
        ///// Gets or sets BlockingReasonKyc
        ///// </summary>
        //public string BlockingReasonKyc { get; set; }
        ///// <summary>
        ///// Gets or sets UrlPhotoProfile
        ///// </summary>
        //public string UrlPhotoProfile { get; set; }
        ///// <summary>
        ///// Gets or sets UrlPhotoIdentificationDocumentObserve
        ///// </summary>
        //public string UrlPhotoIdentificationDocumentObserve { get; set; }
        ///// <summary>
        ///// Gets or sets UrlPhotoIdentificationDocumentReverse
        ///// </summary>
        //public string UrlPhotoIdentificationDocumentReverse { get; set; }
        ///// <summary>
        ///// Gets or sets UrlCurrentPhotoWithIdentificationDocument
        ///// </summary>
        //public string UrlCurrentPhotoWithIdentificationDocument { get; set; }
        ///// <summary>
        ///// Gets or sets StatusKyc
        ///// </summary>
        //public int StatusKyc { get; set; }
        ///// <summary>
        ///// Gets or sets Role
        ///// </summary>
        //public int Role { get; set; }
        ///// <summary>
        ///// Gets or sets Status
        ///// </summary>
        //public int Status { get; set; }
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        //public string Id { get; set; }
        ///// <summary>
        ///// Gets or sets RecordActive
        ///// </summary>
        //public string RecordActive { get; set; }
        ///// <summary>
        ///// Gets or sets CreatedAt
        ///// </summary>
        //public DateTime CreatedAt { get; set; }
        ///// <summary>
        ///// Gets or sets UpdatedAt
        ///// </summary>
        //public DateTime UpdatedAt { get; set; }
        #endregion
    }
}
