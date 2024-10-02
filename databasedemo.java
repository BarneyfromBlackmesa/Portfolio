import java.security.NoSuchAlgorithmException;
import java.util.InputMismatchException;
import java.util.Scanner;
import java.util.HashMap;
import java.util.Map;
import java.util.Set;
import java.util.UUID;
//An edit of my original program - this version separates each function into individual methods
public class DatabaseDemo {
   //The reason why I have this here is to initialize all the variables we need - I put them here so
   //That they are initialized throughout all the program, including the various methods
   private static final Scanner keyboard = new Scanner(System.in);
   private static RSACipher rsaCipher = null;
   static {
       try {
           rsaCipher = new RSACipher();
       } catch (NoSuchAlgorithmException e) {
           //noinspection CallToPrintStackTrace
           e.printStackTrace();
           System.exit(-1); // Exit the program if RSA algorithm isn't available.
       }
   }
   private static final HashMap<UUID, Constituent> database = new HashMap<>();
   private static int option;
   private static final UUID jimId = UUID.randomUUID();
   private static final int VIEW_DATABASE = 1;
   private static final int ADD_CONSTITUENT = 2;
   private static final int SEARCH_CONSTITUENT = 3;
   private static final int EDIT_CONSTITUENT = 4;
   private static final int CLOSE_DATABASE = 5;


   public static void main(String[] args) {
       Constituent jim = new Constituent("Jim Banks", 38, "Cuyahoga", "Republican");
       database.put(jimId, jim);
       boolean working = true;
       while (working) {
           displayMenu();
           try {
               switch (option) {


                   case VIEW_DATABASE: {
                       viewDatabase();
                       break;
                   }
                   case ADD_CONSTITUENT: {
                       addConstituent();
                       break;
                   }
                   case SEARCH_CONSTITUENT: {
                       searchConstituent();
                       break;
                   }
                   case EDIT_CONSTITUENT: {
                       editConstituent();
                       break;
                   }
                   case CLOSE_DATABASE: {
                       System.out.println("Closing database...");
                       working = false;
                       break;
                   }
                   default: {
                       System.out.println("Invalid option! Please only select integers 1-5.");
                   }
               }
           } catch (InputMismatchException e) {
               System.out.println("Invalid option! Please try again.");
           } catch (RuntimeException e) {
               System.out.println("An error occurred. Please try again.");
           }
       }
   }


   //This method allows the user to view the current entries in the database.
   public static void viewDatabase() {
       Set<Map.Entry<UUID, Constituent>> entries = database.entrySet();
       for (Map.Entry<UUID, Constituent> entry : entries) {
           System.out.println(entry.getValue());
       }
   }


   //This method fires at the beginning of the while loop - showing the menu options.
   private static void displayMenu() {
       do {
           System.out.println("\nConstituent Database Options:");
           System.out.println("1: View Database - Display all records");
           System.out.println("2: Add Constituent - Enter details for a new record");
           System.out.println("3: Search Constituent - Find a record by ID");
           System.out.println("4: Edit Constituent - Modify an existing record");
           System.out.println("5: Close Database - Exit the program");
           System.out.print("Please select an option (1-5): ");
           try {
               option = keyboard.nextInt();
               keyboard.nextLine();  // Consume the newline left-over
               break;  // Exit the loop if input is successful
           } catch (InputMismatchException e) {
               System.out.println("Invalid input! Please enter a number between 1 and 5.");
               keyboard.nextLine();  // Consume the bad input
           } catch (NumberFormatException e) {
               System.out.println("Invalid input! Please enter a valid number.");
           } catch (RuntimeException e) {
               System.out.println("An error occurred. Please try again.");
           }
       } while (true);
   }


   //This allows the user to add a constituent should they wish to
   private static void addConstituent() {
       System.out.println("Please enter the name of the new Constituent: ");
       try {
           String newName = rsaCipher.encryptData(keyboard.nextLine());
           int newAge;
           UUID newId = UUID.randomUUID();
           while (true) {
               System.out.println("Please enter the age of the new Constituent: ");
               String inputAge = keyboard.nextLine();
               try {
                   newAge = Integer.parseInt(inputAge); // Attempts to convert the input into an integer
                   break; // Breaks the loop if successful
               } catch (NumberFormatException e) {
                   System.out.println("Invalid age. Please enter a valid number."); // Handles non-integer inputs
               }
           }


           System.out.println("Please enter the county of the new Constituent: ");
           String newCounty = rsaCipher.encryptData(keyboard.nextLine());


           System.out.println("Please enter the party affiliation of the new Constituent: ");
           String newAffiliation = rsaCipher.encryptData(keyboard.nextLine());


           Constituent newConstituent = new Constituent(newName, newAge, newCounty, newAffiliation);
           database.put(newId, newConstituent); // Adds the new constituent with a unique ID
           System.out.println("Added constituent to the database.");


       } catch (Exception e) {
           System.out.println("An error occurred during encryption. Please try again.");
       }
   }


   //This allows the user to search a constituent should they wish to
   private static void searchConstituent() {
       System.out.println("Enter constituent ID: ");
       String input = keyboard.next();
       try {
           UUID keySearch = UUID.fromString(input);
           if (database.containsKey(keySearch)) {
               System.out.println(database.get(keySearch));
           } else {
               System.out.println("Constituent not found in the database.");
           }
       } catch (IllegalArgumentException e) {
           System.out.println("Invalid UUID entered.");
       }
   }


   //This method allows the user to edit a constituent should they wish to
   private static void editConstituent() {
       System.out.println("Enter constituent ID: ");
       UUID keySearch = UUID.randomUUID();
       keyboard.nextLine();


       if (database.containsKey(keySearch)) {
           System.out.println("\nWhat would you like to edit?");
           System.out.println("1 - Name");
           System.out.println("2 - Age");
           System.out.println("3 - County");
           System.out.println("4 - Party Affiliation");
           int selection = keyboard.nextInt();
           try {
               switch (selection) {
                   case 1: {
                       System.out.println("Enter new name: ");
                       keyboard.nextLine();
                       String newName = keyboard.nextLine();
                       database.get(keySearch).setName(newName);
                       System.out.println("Name updated!");
                       break;
                   }
                   case 2: {
                       System.out.println("Enter new age: ");
                       int newAge = keyboard.nextInt();
                       database.get(keySearch).setAge(newAge);
                       System.out.println("Age updated!");
                       break;
                   }
                   case 3: {
                       System.out.println("Enter new county: ");
                       keyboard.nextLine();
                       String newCounty = keyboard.nextLine();
                       database.get(keySearch).setCounty(newCounty);
                       System.out.println("County updated!");
                       break;
                   }
                   case 4: {
                       System.out.println("Enter new party affiliation: ");
                       keyboard.nextLine();
                       String newAffiliation = keyboard.nextLine();
                       database.get(keySearch).setAffiliation(newAffiliation);
                       System.out.println("Party affiliation updated!");
                       break;
                   }
                   default:
                       System.out.println("Invalid option! Please try again");
               }
           } catch (IllegalArgumentException e) {
               System.out.println("Please enter a number 1-4");
               keyboard.nextLine();
           } catch (RuntimeException e) {
               System.out.println("An error occurred. Please try again.");
           }
       }
       else {
           System.out.println("Constituent ID not found. Please try again.");
       }
   }
}
