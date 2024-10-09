public class Constituent {
    private String name;
    private int age;
    private String county;
    private String affiliation;

    public Constituent(String name, int age, String county, String affiliation) {
        this.name = name;
        this.age = age;
        this.county = county;
        this.affiliation = affiliation;
    }

    // Getters and Setters
    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    public String getCounty() {
        return county;
    }

    public void setCounty(String county) {
        this.county = county;
    }

    public String getAffiliation() {
        return affiliation;
    }

    public void setAffiliation(String affiliation) {
        this.affiliation = affiliation;
    }

    @Override
    public String toString() {
        return "Name: " + name + "\nAge: " + age + "\nCounty: " + county + "\nAffiliation: " + affiliation;
    }
}
