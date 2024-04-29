﻿namespace DM._Application.Contracts.ColleagueDiscounts
{
    public class ColleagueDiscountViewModel
    {
        public long Id { get; set; }
        public long ProductId { get;  set; }
        public string Product { get; set; }
        public int DiscountRate { get;  set; }
        public string CreationDate { get; set; }
    }
}
