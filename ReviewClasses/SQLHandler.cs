using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using System.Data;
using Microsoft.Win32;

namespace ReviewClasses
{
    public class SQLHandler
    {
        DBConnect objDB;

        public SQLHandler()
        {
            objDB = new DBConnect();
        }

        public DataSet getRestaurants()
        {
            SqlCommand getRest = new SqlCommand();
            getRest.CommandType = System.Data.CommandType.StoredProcedure;
            getRest.CommandText = "GetAllRestaurants";
            DataSet data = objDB.GetDataSetUsingCmdObj(getRest);
            return data;
        }

        public DataSet getFilteredRestaurants(string category)
        {
            SqlCommand filterCommand = new SqlCommand();

            filterCommand.CommandType = System.Data.CommandType.StoredProcedure;
            filterCommand.CommandText = "FilterRestaurants";
            SqlParameter cat = new SqlParameter("@category", category);
            cat.Direction = System.Data.ParameterDirection.Input;
            cat.SqlDbType = System.Data.SqlDbType.VarChar;
            cat.Size = 50;
            filterCommand.Parameters.Add(cat);

            DataSet rests = objDB.GetDataSetUsingCmdObj(filterCommand);
            return rests;
        }

        public int loginValidation(string username, string type)
        {
            SqlCommand loginCommand = new SqlCommand();

            loginCommand.CommandType = System.Data.CommandType.StoredProcedure;
            loginCommand.CommandText = "ValidateLogin";
            SqlParameter userID = new SqlParameter("@userID", username);
            userID.Direction = System.Data.ParameterDirection.Input;
            userID.SqlDbType = System.Data.SqlDbType.VarChar;
            userID.Size = 50;
            loginCommand.Parameters.Add(userID);

            SqlParameter userType = new SqlParameter("@userType", type);
            userType.Direction = System.Data.ParameterDirection.Input;
            userType.SqlDbType = System.Data.SqlDbType.VarChar;
            userType.Size = 50;
            loginCommand.Parameters.Add(userType);

            DataSet returnVal = objDB.GetDataSetUsingCmdObj(loginCommand);
            int value = Int32.Parse(returnVal.Tables[0].Rows[0][0].ToString());

            return value;
        }

        public int uniqueUserValidation(string username)
        {
            SqlCommand uniqueCommand = new SqlCommand();
            uniqueCommand.CommandType = System.Data.CommandType.StoredProcedure;
            uniqueCommand.CommandText = "UsernameCheck";
            SqlParameter userID = new SqlParameter("@userID", username);
            userID.Direction = System.Data.ParameterDirection.Input;
            userID.SqlDbType = System.Data.SqlDbType.VarChar;
            userID.Size = 50;
            uniqueCommand.Parameters.Add(userID);

            DataSet returnVal = objDB.GetDataSetUsingCmdObj(uniqueCommand);
            int value = Int32.Parse(returnVal.Tables[0].Rows[0][0].ToString());
            return value;
        }

        public DataSet getRestNoReps()
        {
            SqlCommand noRepCommand = new SqlCommand();
            noRepCommand.CommandType = System.Data.CommandType.StoredProcedure;
            noRepCommand.CommandText = "GetRestNoReps";
            DataSet rests = objDB.GetDataSetUsingCmdObj(noRepCommand);
            return rests;
        }

        public void addRepToRest(string representative, string restName)
        {
            SqlCommand repCommand = new SqlCommand();
            repCommand.CommandType = System.Data.CommandType.StoredProcedure;
            repCommand.CommandText = "AddReptoRest";
            SqlParameter rep = new SqlParameter("@Representative", representative);
            rep.Direction = System.Data.ParameterDirection.Input;
            rep.SqlDbType = System.Data.SqlDbType.VarChar;
            rep.Size = 50;
            repCommand.Parameters.Add(rep);

            SqlParameter name = new SqlParameter("@RestName", restName);
            name.Direction = System.Data.ParameterDirection.Input;
            name.SqlDbType = System.Data.SqlDbType.VarChar;
            name.Size = 50;
            repCommand.Parameters.Add(name);

            objDB.DoUpdateUsingCmdObj(repCommand);
        }

        public DataSet getRepresentative(string restName)
        {
            SqlCommand repCommand = new SqlCommand();
            repCommand.CommandType = System.Data.CommandType.StoredProcedure;
            repCommand.CommandText = "GetRepresentative";

            SqlParameter rest = new SqlParameter("@restName", restName);
            rest.Direction = System.Data.ParameterDirection.Input;
            rest.SqlDbType = System.Data.SqlDbType.VarChar;
            rest.Size = 50;
            repCommand.Parameters.Add(rest);

            DataSet represent = objDB.GetDataSetUsingCmdObj(repCommand);
            return represent;
        }

        public DataSet loadRestaurant(string restName)
        {
            SqlCommand loadCommand = new SqlCommand();
            loadCommand.CommandType = System.Data.CommandType.StoredProcedure;
            loadCommand.CommandText = "GetRestaurant";
            SqlParameter rest = new SqlParameter("@restName", restName);
            rest.Direction = System.Data.ParameterDirection.Input;
            rest.SqlDbType = System.Data.SqlDbType.VarChar;
            rest.Size = 50;
            loadCommand.Parameters.Add(rest);
            DataSet restaurant = objDB.GetDataSetUsingCmdObj(loadCommand);
            return restaurant;
        }

        public DataSet loadReviews(string restName)
        {
            SqlCommand reviewsCommand = new SqlCommand();
            reviewsCommand.CommandType = System.Data.CommandType.StoredProcedure;
            reviewsCommand.CommandText = "GetReviews";
            SqlParameter rest = new SqlParameter("@restName", restName);
            rest.Direction = System.Data.ParameterDirection.Input;
            rest.SqlDbType = System.Data.SqlDbType.VarChar;
            rest.Size = 50;
            reviewsCommand.Parameters.Add(rest);

            DataSet reviews = objDB.GetDataSetUsingCmdObj(reviewsCommand);
            return reviews;

        }

        public void addNewReview(Review rev)
        { 
            SqlCommand reviewCommand = new SqlCommand();

            reviewCommand.CommandType = System.Data.CommandType.StoredProcedure;
            reviewCommand.CommandText = "AddReview";
            SqlParameter name = new SqlParameter("@restName", rev.getRestName());
            name.Direction = System.Data.ParameterDirection.Input;
            name.SqlDbType = System.Data.SqlDbType.VarChar;
            name.Size = 50;
            reviewCommand.Parameters.Add(name);

            SqlParameter review = new SqlParameter("@ReviewComment", rev.getComment());
            review.Direction = System.Data.ParameterDirection.Input;
            review.SqlDbType = System.Data.SqlDbType.VarChar;
            review.Size = -1;
            reviewCommand.Parameters.Add(review);

            SqlParameter servRating = new SqlParameter("@ServiceRating", rev.getService());
            servRating.Direction = System.Data.ParameterDirection.Input;
            servRating.SqlDbType = System.Data.SqlDbType.Int;
            reviewCommand.Parameters.Add(servRating);

            SqlParameter qualRating = new SqlParameter("@QualityRating", rev.getQuality());
            qualRating.Direction = System.Data.ParameterDirection.Input;
            qualRating.SqlDbType = System.Data.SqlDbType.Int;
            reviewCommand.Parameters.Add(qualRating);

            SqlParameter priceRating = new SqlParameter("@PriceRating", rev.getPrice());
            priceRating.Direction = System.Data.ParameterDirection.Input;
            priceRating.SqlDbType = System.Data.SqlDbType.Int;
            reviewCommand.Parameters.Add(priceRating);

            SqlParameter atmosRating = new SqlParameter("@AtmosRating", rev.getAtmos());
            atmosRating.Direction = System.Data.ParameterDirection.Input;
            atmosRating.SqlDbType = System.Data.SqlDbType.Int;
            reviewCommand.Parameters.Add(atmosRating);

            SqlParameter user = new SqlParameter("@UserID", rev.getUser());
            user.Direction = System.Data.ParameterDirection.Input;
            user.SqlDbType = System.Data.SqlDbType.VarChar;
            user.Size = 50;
            reviewCommand.Parameters.Add(user);

            objDB.DoUpdateUsingCmdObj(reviewCommand);
        }

        public DataSet getUserReviews(string userID, string restName)
        {
            SqlCommand userReviewsCmd = new SqlCommand();
            userReviewsCmd.CommandType = System.Data.CommandType.StoredProcedure;
            userReviewsCmd.CommandText = "GetUserReviews";

            SqlParameter user = new SqlParameter("@userID", userID);
            user.Direction = System.Data.ParameterDirection.Input;
            user.SqlDbType = System.Data.SqlDbType.VarChar;
            user.Size = 50;
            userReviewsCmd.Parameters.Add(user);

            SqlParameter rest = new SqlParameter("@restName", restName);
            rest.Direction = System.Data.ParameterDirection.Input;
            rest.SqlDbType = System.Data.SqlDbType.VarChar;
            rest.Size = 50;
            userReviewsCmd.Parameters.Add(rest);

            DataSet userReviews = objDB.GetDataSetUsingCmdObj(userReviewsCmd);
            return userReviews;
        }

        public DataSet getAverages(string restName)
        {
            SqlCommand ratingCommand = new SqlCommand();

            ratingCommand.CommandType = System.Data.CommandType.StoredProcedure;
            ratingCommand.CommandText = "GetAverageReviews";
            SqlParameter name = new SqlParameter("@restName", restName);
            name.Direction = System.Data.ParameterDirection.Input;
            name.SqlDbType = System.Data.SqlDbType.VarChar;
            name.Size = 50;
            ratingCommand.Parameters.Add(name);

            DataSet averages = objDB.GetDataSetUsingCmdObj(ratingCommand);
            return averages;
        }

        public DataSet deleteReview(int reviewID, string userID)
        {
            SqlCommand deleteCommand = new SqlCommand();
            deleteCommand.CommandType = System.Data.CommandType.StoredProcedure;
            deleteCommand.CommandText = "DeleteReview";

            SqlParameter ID = new SqlParameter("@reviewID", reviewID);
            ID.Direction = System.Data.ParameterDirection.Input;
            ID.SqlDbType = System.Data.SqlDbType.VarChar;
            ID.Size = 50;
            deleteCommand.Parameters.Add(ID);

            SqlParameter user = new SqlParameter("@userID", userID);
            user.Direction = System.Data.ParameterDirection.Input;
            user.SqlDbType = System.Data.SqlDbType.VarChar;
            user.Size = 50;
            deleteCommand.Parameters.Add(user);

            DataSet delete = objDB.GetDataSetUsingCmdObj(deleteCommand);
            return delete;
        }

        public DataSet getReview(int reviewID)
        {
            SqlCommand ratingCommand = new SqlCommand();

            ratingCommand.CommandType = System.Data.CommandType.StoredProcedure;
            ratingCommand.CommandText = "GetReviewFromID";
            SqlParameter ID = new SqlParameter("@reviewID", reviewID);
            ID.Direction = System.Data.ParameterDirection.Input;
            ID.SqlDbType = System.Data.SqlDbType.VarChar;
            ID.Size = 50;
            ratingCommand.Parameters.Add(ID);

            DataSet review = objDB.GetDataSetUsingCmdObj(ratingCommand);
            return review;

        }

        public void updateReview(int reviewID, string comment, int service, int quality, int price, int atmos, string userID)
        {
            SqlCommand updateCommand = new SqlCommand();

            updateCommand.CommandType = System.Data.CommandType.StoredProcedure;
            updateCommand.CommandText = "UpdateReview";

            SqlParameter ID = new SqlParameter("@reviewID", reviewID);
            ID.Direction = System.Data.ParameterDirection.Input;
            ID.SqlDbType = System.Data.SqlDbType.Int;
            updateCommand.Parameters.Add(ID);

            SqlParameter review = new SqlParameter("@ReviewComment", comment);
            review.Direction = System.Data.ParameterDirection.Input;
            review.SqlDbType = System.Data.SqlDbType.VarChar;
            review.Size = -1;
            updateCommand.Parameters.Add(review);

            SqlParameter servRating = new SqlParameter("@ServiceRating", service);
            servRating.Direction = System.Data.ParameterDirection.Input;
            servRating.SqlDbType = System.Data.SqlDbType.Float;
            updateCommand.Parameters.Add(servRating);

            SqlParameter qualRating = new SqlParameter("@QualityRating", quality);
            qualRating.Direction = System.Data.ParameterDirection.Input;
            qualRating.SqlDbType = System.Data.SqlDbType.Float;
            updateCommand.Parameters.Add(qualRating);

            SqlParameter priceRating = new SqlParameter("@PriceRating", price);
            priceRating.Direction = System.Data.ParameterDirection.Input;
            priceRating.SqlDbType = System.Data.SqlDbType.Float;
            updateCommand.Parameters.Add(priceRating);

            SqlParameter atmosRating = new SqlParameter("@AtmosRating", atmos);
            atmosRating.Direction = System.Data.ParameterDirection.Input;
            atmosRating.SqlDbType = System.Data.SqlDbType.Float;
            updateCommand.Parameters.Add(atmosRating);

            SqlParameter user = new SqlParameter("@UserID", userID);
            user.Direction = System.Data.ParameterDirection.Input;
            user.SqlDbType = System.Data.SqlDbType.VarChar;
            user.Size = 50;
            updateCommand.Parameters.Add(user);

            objDB.DoUpdateUsingCmdObj(updateCommand);
        }

        public void addNewReservation(Reservation res)
        {
            SqlCommand reservationCmd = new SqlCommand();

            reservationCmd.CommandType = System.Data.CommandType.StoredProcedure;
            reservationCmd.CommandText = "AddReservation";

            SqlParameter resDateTime = new SqlParameter("@reservationDateTime", res.getResTime());
            resDateTime.Direction = System.Data.ParameterDirection.Input;
            resDateTime.SqlDbType = System.Data.SqlDbType.DateTime;
            reservationCmd.Parameters.Add(resDateTime);

            SqlParameter partyNum = new SqlParameter("@numInParty", res.getParty());
            partyNum.Direction = System.Data.ParameterDirection.Input;
            partyNum.SqlDbType = System.Data.SqlDbType.Int;
            reservationCmd.Parameters.Add(partyNum);

            SqlParameter reservName = new SqlParameter("@name", res.getName());
            reservName.Direction = System.Data.ParameterDirection.Input;
            reservName.SqlDbType = System.Data.SqlDbType.VarChar;
            reservName.Size = 50;
            reservationCmd.Parameters.Add(reservName);

            SqlParameter restaurantName = new SqlParameter("@restName", res.getRestName());
            restaurantName.Direction = System.Data.ParameterDirection.Input;
            restaurantName.SqlDbType = System.Data.SqlDbType.VarChar;
            restaurantName.Size = 50;
            reservationCmd.Parameters.Add(restaurantName);

            objDB.DoUpdateUsingCmdObj(reservationCmd);
        }

        public DataSet getReservations(string restName)
        {
            SqlCommand resCommand = new SqlCommand();
            resCommand.CommandType = System.Data.CommandType.StoredProcedure;
            resCommand.CommandText = "GetReservations";
            SqlParameter rest = new SqlParameter("@restName", restName);
            rest.Direction = System.Data.ParameterDirection.Input;
            rest.SqlDbType = System.Data.SqlDbType.VarChar;
            rest.Size = 50;
            resCommand.Parameters.Add(rest);

            DataSet reservations = objDB.GetDataSetUsingCmdObj(resCommand);
            return reservations;
        }

        public DataSet deleteReservation(int resID, string userID, string restName)
        {
            SqlCommand deleteResCommand = new SqlCommand();
            deleteResCommand.CommandType = System.Data.CommandType.StoredProcedure;
            deleteResCommand.CommandText = "DeleteReservation";

            SqlParameter ID = new SqlParameter("@reservationID", resID);
            ID.Direction = System.Data.ParameterDirection.Input;
            ID.SqlDbType = System.Data.SqlDbType.Int;
            deleteResCommand.Parameters.Add(ID);

            SqlParameter user = new SqlParameter("@userID", userID);
            user.Direction = System.Data.ParameterDirection.Input;
            user.SqlDbType = System.Data.SqlDbType.VarChar;
            user.Size = 50;
            deleteResCommand.Parameters.Add(user);

            SqlParameter rest = new SqlParameter("@restName", restName);
            rest.Direction = System.Data.ParameterDirection.Input;
            rest.SqlDbType = System.Data.SqlDbType.VarChar;
            rest.Size = 50;
            deleteResCommand.Parameters.Add(rest);

            DataSet reservation = objDB.GetDataSetUsingCmdObj(deleteResCommand);
            return reservation;

        }

        public DataSet getReservation(int resID)
        {
            SqlCommand getResCommand = new SqlCommand();

            getResCommand.CommandType = System.Data.CommandType.StoredProcedure;
            getResCommand.CommandText = "GetResFromID";
            SqlParameter ID = new SqlParameter("@resID", resID);
            ID.Direction = System.Data.ParameterDirection.Input;
            ID.SqlDbType = System.Data.SqlDbType.Int;
            getResCommand.Parameters.Add(ID);

            DataSet res = objDB.GetDataSetUsingCmdObj(getResCommand);
            return res;
        }

        public void updateReservation(int resID, string userID, string restName, DateTime resTime, int party, string resName)
        {
            SqlCommand updateResCommand = new SqlCommand();

            updateResCommand.CommandType = System.Data.CommandType.StoredProcedure;
            updateResCommand.CommandText = "UpdateReservation";

            SqlParameter ID = new SqlParameter("@resID", resID);
            ID.Direction = System.Data.ParameterDirection.Input;
            ID.SqlDbType = System.Data.SqlDbType.Int;
            updateResCommand.Parameters.Add(ID);

            SqlParameter user = new SqlParameter("@userID", userID);
            user.Direction = System.Data.ParameterDirection.Input;
            user.SqlDbType = System.Data.SqlDbType.VarChar;
            user.Size = 50;
            updateResCommand.Parameters.Add(user);

            SqlParameter rest = new SqlParameter("@restName", restName);
            rest.Direction = System.Data.ParameterDirection.Input;
            rest.SqlDbType = System.Data.SqlDbType.VarChar;
            rest.Size = 50;
            updateResCommand.Parameters.Add(rest);

            SqlParameter timeRes = new SqlParameter("@resDateTime", resTime);
            timeRes.Direction = System.Data.ParameterDirection.Input;
            timeRes.SqlDbType = System.Data.SqlDbType.DateTime;
            updateResCommand.Parameters.Add(timeRes);

            SqlParameter num = new SqlParameter("@numParty", party);
            num.Direction = System.Data.ParameterDirection.Input;
            num.SqlDbType = System.Data.SqlDbType.Int;
            updateResCommand.Parameters.Add(num);

            SqlParameter name = new SqlParameter("@resName", resName);
            name.Direction = System.Data.ParameterDirection.Input;
            name.SqlDbType = System.Data.SqlDbType.VarChar;
            name.Size = 50;
            updateResCommand.Parameters.Add(name);

            objDB.DoUpdateUsingCmdObj(updateResCommand);

        }

        public void updateRestaurant(string restName, string desc, string userID, string cat, string image)
        {
            SqlCommand updateRestCommand = new SqlCommand();

            updateRestCommand.CommandType = System.Data.CommandType.StoredProcedure;
            updateRestCommand.CommandText = "UpdateRestaurant";

            SqlParameter rest = new SqlParameter("@restName", restName);
            rest.Direction = System.Data.ParameterDirection.Input;
            rest.SqlDbType = System.Data.SqlDbType.VarChar;
            rest.Size = 50;
            updateRestCommand.Parameters.Add(rest);

            SqlParameter description = new SqlParameter("@desc", desc);
            description.Direction = System.Data.ParameterDirection.Input;
            description.SqlDbType = System.Data.SqlDbType.VarChar;
            description.Size = -1;
            updateRestCommand.Parameters.Add(description);

            SqlParameter user = new SqlParameter("@userID", userID);
            user.Direction = System.Data.ParameterDirection.Input;
            user.SqlDbType = System.Data.SqlDbType.VarChar;
            user.Size = 50;
            updateRestCommand.Parameters.Add(user);

            SqlParameter category = new SqlParameter("@category", cat);
            category.Direction = System.Data.ParameterDirection.Input;
            category.SqlDbType = System.Data.SqlDbType.VarChar;
            category.Size = 50;
            updateRestCommand.Parameters.Add(category);

            SqlParameter imageurl = new SqlParameter("@imageURL", image);
            imageurl.Direction = System.Data.ParameterDirection.Input;
            imageurl.SqlDbType = System.Data.SqlDbType.VarChar;
            imageurl.Size = -1;
            updateRestCommand.Parameters.Add(imageurl);

            objDB.DoUpdateUsingCmdObj(updateRestCommand);
        }

    }
}
