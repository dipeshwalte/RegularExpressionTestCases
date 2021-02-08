using System;

namespace RegularExpressionTestCases
{
    using System;
    using System.Text.RegularExpressions;

    public class UserValidation
        {
            static void ValidatePatterns(string pattern, string[] inputs)
            {
                Console.WriteLine("------------------------------------------");
                Regex re = new Regex(pattern);
                foreach (string input in inputs)
                {
                    if (re.IsMatch(input))
                        Console.WriteLine($"{input} is Valid");
                    else
                        Console.WriteLine($"{input} is inValid");
                }
                Console.WriteLine("-----------------------------------------");
            }
            public bool ValidatePattern(string pattern, string input)
            {
                Regex re = new Regex(pattern);
                return re.IsMatch(input);
            }
            
            static void Main(string[] args)
            {
                string firstNamePattern = "[A-Z][a-z]{2,}";
                string[] firstNameInputs = { "dipesh", "Dipesh", "Di", "Dinesh", "Dha", "Dhanesh" };
                ValidatePatterns(firstNamePattern, firstNameInputs);

                string lastNamePattern = "[A-Z][a-z]{2,}";
                string[] lastNameInputs = { "walte", "Walte", "Wa", "Zokhowizh", "Wha" };
                ValidatePatterns(lastNamePattern, lastNameInputs);

                string emailPattern = @"^[0-9a-zA-Z]+[\-\.+]?[A-Za-z0-9]*@[0-9A-Za-z]+\.[a-zA-Z]{2,4}\.?([a-zA-Z]{2,4})?$";
                string[] emailInputs = { "abc.xyz@bl.co.in", "abc@bl.co", "abc@bl", "abc@bc.com" };
                ValidatePatterns(emailPattern, emailInputs);

                string phonePattern = @"^[0-9]{2}\s[0-9]{10}$";
                string[] phoneInputs = { "91 9422421317", "54 942242131", "9422421315", "9 9422421317" };
                ValidatePatterns(phonePattern, phoneInputs);

                string passwordPattern = @"(?=.*[A-Z])(?=.*[0-9])(?=[^.,:;'!@#$%^&*_+=|(){}[?\-\]\/\\]*[.,:;'!@#$%^&*_+=|(){}[?\-\]\/\\][^.,:;'!@#$%^&*_+=|(){}[?\-\]\/\\]*$)[0-9A-Za-z!@#\$%\^&\*\(\)\-\+]{8,}";
                string[] passwordInputs = { "1A!2345678", "1!!Asrwerds", "fdsaf", "fetsetv!", "12345678A" };
                ValidatePatterns(passwordPattern, passwordInputs);

                string emailPattern2 = @"^[0-9a-zA-Z]+[\-\.+]?[A-Za-z0-9]+@[0-9A-Za-z]+\.[a-zA-Z]{2,4}\.?([a-zA-Z]{2,4})?$";
                string[] emailAllInputs = { "abc@yahoo.com",
                                        "abc-100@yahoo.com",
                                        "abc.100@yahoo.com",
                                        "abc111@abc.com",
                                        "abc-100@abc.net",
                                        "abc.100@abc.com.au",
                                        "abc@1.com",
                                        "abc@gmail.com.com",
                                        "abc+100@gmail.com",
                                        "abc",
                                        "abc@.com.my",
                                        "abc123@gmail.a",
                                        "abc123@.com",
                                        "abc123@.com.com",
                                        ".abc@abc.com",
                                        "abc()*@gmail.com",
                                        "abc@%*.com",
                                        "abc..2002@gmail.com",
                                        "abc.@gmail.com",
                                        "abc@abc@gmail.com",
                                        "abc@gmail.com.1a",
                                        "abc@gmail.com.aa.au",
                                           };
                ValidatePatterns(emailPattern2, emailAllInputs);


            }
        }
    

}
