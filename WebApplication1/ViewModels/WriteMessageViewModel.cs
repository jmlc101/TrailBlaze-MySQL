using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class WriteMessageViewModel
    {
        private string _body;

        public int SendersID { get; set; }

        public int RecieversID { get; set; }

        public string Body {
            get { return this._body; }
            set {
                int num = value.Count();
                if (num < 40)
                {
                    _body = value;
                }
                else
                {
                    string newBody = "";
                    int charCount = 1;
                    foreach (char item in value)
                    {
                        if (charCount < 40)
                        {
                            newBody = (newBody + item);
                            charCount += 1;
                        }
                        else
                        {
                            newBody = (newBody + item);
                            newBody = (newBody + System.Environment.NewLine);
                            charCount = 1;
                        }

                    }
                    _body = newBody;
                }
                ; }
        }

        public string ProfileUserScreenName { get; set; }

        public string SendAMessageButtonCheck { get; set; }
    }
}
