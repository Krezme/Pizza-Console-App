using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Console_Application
{
    class Program
    {
        //client details
        string clientName;
        string clientAddress;
        string clientPhoneNum;

        string userInputForDelivery;

        //Quantity of Pizzas Ordered
        int quantityOfPizzasOrdered;

        double totalCostOfOrder;
        double costForToppingsTotal;
        double costForPizzasTotal;
        double grantTotal;


        //Cost for pizza sizes
        double smallPizzaSizeCost = 3.25;
        double mediumPizzaSizeCost = 5.50;
        double largePizzaSizeCost = 7.15;

        //Cost for extra toppings
        double oneExtraToppingCost = 0.75;
        double twoExtraToppingCost = 1.35;
        double threeExtraToppingCost = 2.00;
        double fourOrMoreExtraToppingCost = 2.50;

        //Delivery cost
        double deliveryCost = 2.50;

        //array to record sizes of ordered pizzas
        int[] orderedPizzaSizes = new int[3];
        //array to record if toppings are added
        int[] toppingsAdded = new int[4];

        //variable to record if delivery to address is requested
        bool deliveryRequest;


        //Main method to run the program
        static void Main(string[] args)
        {
            //program varable to allow me to reffer other methods in the Main method
            Program program = new Program();
            //Reffering to the ProgramAssembly method
            program.ProgramAssembly();
        }

        //Method to assemble the program
        void ProgramAssembly() {
            //Reffering to the GettingClientDetails method
            GettingClientDetails();
            //Reffering to the GettingClintOrder method
            GettingClintOrder();
            //Reffering to the Delivery method
            Delivery();
            //Reffering to the CalculatingBill method
            CalculatingBill();
            //Reffering to the Bill method
            Bill();
            Console.ReadKey();
        }

        //Method to process all the user inputs for client name, client address and client phone number
        void GettingClientDetails() {
            //Reffering to the ClientName method
            ClientName();

            //Reffering to the ClientAddress method
            ClientAddress();

            //Reffering to the ClientPhoneNumber method
            ClientPhoneNumber();
        }

        //Method to hold the entering and validation of user input functionality
        void ClientName() {
            //Requesting for client name
            Console.WriteLine("Enter client name: ");
            //Waiting for user input
            clientName = Console.ReadLine();
            bool isItOnlyLetters = clientName.All(Char.IsLetter);
            //To check if the user input is valid
            if (string.IsNullOrWhiteSpace(clientName) || isItOnlyLetters == false)
            {
                Console.WriteLine("Please enter valid name.");
                Console.WriteLine("Press any key to continue and Try Again.");
                Console.ReadKey();
                ClientName();
            }
        }

        //Method to hold the entering and validation of client address functionality 
        void ClientAddress() {
            //Requesting for client address
            Console.WriteLine("Enter client address: ");
            //Waiting for user input
            clientAddress = Console.ReadLine();
            //To check if the user input is valid
            if (string.IsNullOrWhiteSpace(clientAddress))
            {
                Console.WriteLine("Please enter valid address.");
                Console.WriteLine("Press any key to continue and Try Again.");
                Console.ReadKey();
                ClientAddress();
            }
        }

        //Method to hold the entering and validation of client phone number functionality 
        void ClientPhoneNumber() {
            //Requesting for client phone number
            Console.WriteLine("Enter client phone number: ");
            //Waiting for user input
            clientPhoneNum = Console.ReadLine();
            //To check if the user input is valid
            if (string.IsNullOrWhiteSpace(clientPhoneNum))
            {
                Console.WriteLine("Please enter valid phone number.");
                Console.WriteLine("Press any key to continue and Try Again.");
                Console.ReadKey();
                ClientPhoneNumber();
            }
        }

        //Method to process all the user inputs for quantity of pizzas ordered, pizza sizes order and topping order
        void GettingClintOrder() {
            QuantityOfPizzasOrdered();

            PizzaSizesOrder();

            ToppingsOrder();
        }

        //Method to hold the entering and validation of quantity of pizzas ordered functionality 
        void QuantityOfPizzasOrdered() {
            //Trying the code for any exeptions
            try {
                //Requesting a number of pizzas ordered
                Console.WriteLine("Quantity of pizzas ordered: ");
                //Waighting for user input
                quantityOfPizzasOrdered = Convert.ToInt32(Console.ReadLine());
                //Checking if user input is valid
                if (quantityOfPizzasOrdered <= 0 || quantityOfPizzasOrdered > 6) {
                    Console.WriteLine("Please enter a valid number between the minimum of 1 and the maximum of 6.");
                    Console.WriteLine("Press any key to continue and Try Again.");
                    Console.ReadKey();
                    QuantityOfPizzasOrdered();
                }
            } 
            //Detecting any exeptions and responding
            catch (Exception) {
                Console.WriteLine("Please enter the amound of pizzas ordered in numbers between 1 and 6.");
                Console.WriteLine("Press any key to continue and Try Again.");
                Console.ReadKey();
                QuantityOfPizzasOrdered();
            }
        }

        //Method to hold the entering and validation of quantity of pizza sizes order functionality 
        void PizzaSizesOrder() {
            //Trying the code for any exeptions
            try
            {
                //Requesting a number small size pizzas
                Console.WriteLine("Enter quantity of small pizzas ordered: ");
                orderedPizzaSizes[0] = Convert.ToInt32(Console.ReadLine());
                if (orderedPizzaSizes[0] < 0) {
                	Console.WriteLine("Invalid number of pizzas entered. Please enter a valid number of pizzas");
                	Console.WriteLine("Press any key to continue and Try Again.");
                	PizzaSizesOrder();
                }

                //Requesting a number medium size pizzas
                Console.WriteLine("Enter quantity of medium pizzas ordered: ");
                orderedPizzaSizes[1] = Convert.ToInt32(Console.ReadLine());

                //Requesting a number large size pizzas
                Console.WriteLine("Enter quantity of large pizzas ordered: ");
                orderedPizzaSizes[2] = Convert.ToInt32(Console.ReadLine());

                //Cheching if the sum of the entered size pizzas is correct
                if ((orderedPizzaSizes[0] + orderedPizzaSizes[1] + orderedPizzaSizes[2]) != quantityOfPizzasOrdered) {
                    Console.WriteLine("Please enter the right number of pizzas which is: " + quantityOfPizzasOrdered);
                    Console.WriteLine("Press any key to continue and Try Again.");
                    Console.ReadLine();
                    PizzaSizesOrder();
                }
            }
            //Detecting any exeptions and responding
            catch (Exception) {
                Console.WriteLine("Please enter number of pizzas for each size.");
                Console.WriteLine("Press any key to continue and Try Again.");
                Console.ReadLine();
                PizzaSizesOrder();
            }
        }

        //Method to hold the entering and validation of quantity of topping order functionality 
        void ToppingsOrder() {
            //Trying the code for any exeptions
            try
            {
                //Requesting a number for how many one extra toppings are ordered
                Console.WriteLine("Enter how many one extra toppings are ordered: ");
                toppingsAdded[0] = Convert.ToInt32(Console.ReadLine());

                //Requesting a number for how many two extra toppings are ordered
                Console.WriteLine("Enter how many two extra toppings are ordered: ");
                toppingsAdded[1] = Convert.ToInt32(Console.ReadLine());

                //Requesting a number for how many three extra toppings are ordered
                Console.WriteLine("Enter how many three extra toppings are ordered: ");
                toppingsAdded[2] = Convert.ToInt32(Console.ReadLine());

                //Requesting a number for how many four or more extra toppings are ordered
                Console.WriteLine("Enter how many four or more extra toppings are ordered: ");
                toppingsAdded[3] = Convert.ToInt32(Console.ReadLine());
            }
            //Detecting any exeptions and responding
            catch (Exception) {
                Console.WriteLine("Please enter a valid input for the toppings ordered.");
                Console.WriteLine("Press any key to continue and Try Again.");
                Console.ReadLine();
                ToppingsOrder();
            }
        }

        //Method to deside if a discound is in order
        void Delivery() {
            //Requesting a T or F if delivery is requested
            Console.WriteLine("If delivery is requested enter 'T' if not enter 'F': ");
            //Waiting for user input
            userInputForDelivery = Console.ReadLine();

            //Disiding on an value for the deliveryRequest vasiable based on the user input
            if (userInputForDelivery == "T" || userInputForDelivery == "t")
            {
                deliveryRequest = true;
            }
            else if (userInputForDelivery == "F" || userInputForDelivery == "f")
            {
                deliveryRequest = false;
            }
            else
            {
                Console.WriteLine("Please enter a valid answer.");
                Console.WriteLine("Press any key to continue and Try Again.");
                Console.ReadKey();
                Delivery();
            }
        }

        //Method calculating the client bill 
        void CalculatingBill() {
            costForPizzasTotal = (orderedPizzaSizes[0] * smallPizzaSizeCost) + (orderedPizzaSizes[1] * mediumPizzaSizeCost) + (orderedPizzaSizes[2] * largePizzaSizeCost);
            costForToppingsTotal = (toppingsAdded[0] * oneExtraToppingCost) + (toppingsAdded[1] * twoExtraToppingCost) + (toppingsAdded[2] * threeExtraToppingCost) + (toppingsAdded[3] * fourOrMoreExtraToppingCost);
            totalCostOfOrder = costForPizzasTotal + costForToppingsTotal;
            if (totalCostOfOrder >= 20) {
                grantTotal = ((totalCostOfOrder / 100) * 90);
            }
            if (deliveryRequest == true) {
                grantTotal = grantTotal + deliveryCost;
            }
        }

        //Prinding Bill

        void Bill() {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("====================   BILL   ===================");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine("Order for " + clientName);
            Console.WriteLine("Client Address: " + clientAddress);
            Console.WriteLine("Client Phone Number :" + clientPhoneNum);
            Console.WriteLine(" ");

            if (orderedPizzaSizes[0] != 0)
            {
                Console.WriteLine("Small pizza/s * " + orderedPizzaSizes[0] + "   £" + orderedPizzaSizes[0] * smallPizzaSizeCost);
            }
            if (orderedPizzaSizes[1] != 0)
            {
                Console.WriteLine("Small pizza/s * " + orderedPizzaSizes[1] + "   £" + orderedPizzaSizes[1] * mediumPizzaSizeCost);
            }
            if (orderedPizzaSizes[2] != 0)
            {
                Console.WriteLine("Small pizza/s * " + orderedPizzaSizes[2] + "   £" + orderedPizzaSizes[2] * largePizzaSizeCost);
            }

            if (toppingsAdded[0] != 0)
            {
                Console.WriteLine("One extra topping * " + toppingsAdded[0] + "   £" + toppingsAdded[0] * oneExtraToppingCost);
            }
            if (toppingsAdded[1] != 0)
            {
                Console.WriteLine("Two Extra toppings * " + toppingsAdded[1] + "   £" + toppingsAdded[1] * twoExtraToppingCost);
            }
            if (toppingsAdded[2] != 0)
            {
                Console.WriteLine("Three extra toppings * " + toppingsAdded[2] + "   £" + toppingsAdded[2] * threeExtraToppingCost);
            }
            if (toppingsAdded[3] != 0)
            {
                Console.WriteLine("Four or more extra toppings * " + toppingsAdded[3] + "   £" + toppingsAdded[3] * fourOrMoreExtraToppingCost);
            }

            if (deliveryRequest == true)
            {
                Console.WriteLine("Delivery cost    £" + deliveryCost);
            }

            if (totalCostOfOrder >= 20)
            {
                Console.WriteLine("Discound 10%    £ -" + ((totalCostOfOrder / 100) * 10));
            }

            Console.WriteLine("Grand total    £" + grantTotal);
        }
    }
}
