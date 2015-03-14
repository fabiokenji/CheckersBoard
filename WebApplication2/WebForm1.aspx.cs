using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Session created to count the number of clicks on the checker board.
                Session["roundCount"] = 1;
            }

            //Calling function to Create Checkers Board.
            Create_Checkers_Board();
        }

        //This function creates the Checkers Board.
        //tblBody is going to receive this board.
        protected void Create_Checkers_Board()
        {
            try
            {
                Table tbl = new Table();
                tbl = (Table)Page.FindControl("tblBody");

                TableRow row;
                TableCell cell;

                //This LinkButton will receive the number of the round.
                LinkButton lnk;

                //Variable to control the creation of the Board.
                Int32 line = 0;
                Int32 column = 0;

                for (line = 0; line < 8; line++)
                {
                    row = new TableRow();

                    for (column = 0; column < 8; column++)
                    {
                        lnk = new LinkButton();
                        lnk.ID = "lnk" + line.ToString() + column.ToString();
                        lnk.Click += lnk_Click;
                        lnk.Height = 35;
                        lnk.Width = 35;
                        lnk.CssClass = "checkersBoardCell";

                        cell = new TableCell();
                        cell.Height = 40;
                        cell.Width = 40;

                        //Color
                        if (line % 2 == 0)
                        {
                            if (column % 2 == 0)
                                cell.BackColor = System.Drawing.Color.Black;
                            else
                                cell.BackColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            if (column % 2 == 0)
                                cell.BackColor = System.Drawing.Color.Red;
                            else
                                cell.BackColor = System.Drawing.Color.Black;
                        }

                        cell.Controls.Add(lnk);
                        row.Controls.Add(cell);
                    }

                    tbl.Controls.Add(row);
                }
            }
            catch (Exception ex)
            {

                lblError.Text = "Function Create_Checkers_Board() :" + ex.Message;
            }


        }

        //Function to delete the current checkers board
        protected void Delete_Checkers_Board()
        {
            try
            {
                Table tbl = new Table();
                tbl = (Table)Page.FindControl("tblBody");

                Int32 i = 0;

                for (i = tbl.Rows.Count - 1; i >= 0; i--)
                {
                    tbl.Rows.RemoveAt(i);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Function Delete_Checkers_Board() :" + ex.Message;
            }

        }

        //OnClick event btnStart
        //It will set the Labels at the top of the page using the contents of the TextBoxes
        //Delete and Create the Checkers Board.
        //Set the Session roundCount = 1
        protected void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                lblPlayerOne.Text = txtPlayerOneName.Text;
                lblPlayerTwo.Text = txtPlayerTwoName.Text;

                txtPlayerOneName.Text = "";
                txtPlayerTwoName.Text = "";

                Delete_Checkers_Board();
                Create_Checkers_Board();
                Session["roundCount"] = 1;

            }
            catch (Exception ex)
            {

                lblError.Text = "Function btnStart_Click() :" + ex.Message; ;
            }

        }

        //Every cell on the Checkers Board is a LinkButton
        //Find the LinkButton
        //Get value from the Session roundCount
        //Set text to the LinkButton
        //Update Session roundCount
        protected void lnk_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnk = ((LinkButton)sender);
                Int32 vl = Convert.ToInt32(Session["roundCount"].ToString());

                if (lnk.Text == "")
                {
                    lnk.Text = vl.ToString();
                }
                else
                {
                    lnk.Text = "";
                }

                vl++;
                Session["roundCount"] = vl;
            }
            catch (Exception ex)
            {

                lblError.Text = "Function lnk_Click() :" + ex.Message; ;
            }

        }
    }
}