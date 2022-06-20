﻿using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class FeedbackBL : IFeedbackBL
    {
        private readonly IFeedbackRL feedbackRL;

        public FeedbackBL(IFeedbackRL feedbackRL)
        {
            this.feedbackRL = feedbackRL;
        }
        public string AddFeedback(FeedbackModel feedbackModel, int userId)
        {
            try
            {
                return this.feedbackRL.AddFeedback(feedbackModel,userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ViewFeedbackModel> GetFeedback(int BookId)
        {
            try
            {
                return this.feedbackRL.GetFeedback(BookId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
