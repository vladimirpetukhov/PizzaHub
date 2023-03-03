using System.ComponentModel.DataAnnotations;

namespace api.Data.Models.Enums
{
    public enum OrderStatus
    {
        [Display(Name = TYPE_REGISTERED)]
        REGISTERED,

        [Display(Name = TYPE_IN_PREPARATION)]
        PREPARATION,

        [Display(Name = TYPE_READY_TO_BE_DELIVERED)]
        READY_TO_BE_DELIVERED,

        [Display(Name = TYPE_DELIVERED)]
        DELIVERED
    }
}
