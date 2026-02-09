// Base class
class Person {
    protected name: string;
    protected age: number;

    constructor(name: string, age: number) {
        this.name = name;
        this.age = age;
    }

    public introduce(): void {
        console.log(`Hello, my name is ${this.name} and I am ${this.age} years old.`);
    }
}

const person1 = new Person("Alice", 30);
person1.introduce();

// Inheritance
class Employee extends Person {
    private employeeId: number;

    constructor(name: string, age: number, employeeId: number) {
        super(name, age);
        this.employeeId = employeeId;
    }

    public work(): void {
        console.log(`${this.name} is working with employee ID: ${this.employeeId}`);
    }
}

const employee1 = new Employee("Bob", 28, 101);
employee1.introduce();
employee1.work();
