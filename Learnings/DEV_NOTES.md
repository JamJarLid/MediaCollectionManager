## Code Reflection Questions
### Step 1: CLI skeleton
- How is Main() different from Java’s main?
  - It looks largely similar, mostly it seems that the public statement is not used in C#.
    Namespace is a feature I don't recognize from Java either, not sure of its function.
- Why does the program use a while (running) loop instead of recursion or restarting Main?
  - Restarting Main would risk running multiple instances of the Program.
    A recursion would similarly run the program fully, thus not being able to keep it contained on a single thread.
### Step 2: First Domain Class
- Why is constructor validation important?
  - Constructor validation makes sure that no "broken" class instances are created, with properties of invalid types or ranges. This makes sure that the methods used for these class instances will work as expected. 
- What happens if properties were public and mutable?
  - Then the central data for the videogames can be changed at will, like the title.
- Is this class responsible for behavior or just data?
  - I would say that some behavior can be put in this class, when it is specific behavior that is only relevant to the class instance. 
### Step 3: Managing a Collection
- Why is the list private?
  - The list is private in order to ensure that it can only be altered through the methods in the Service. 
- Why not return the raw List directly?
  - The raw list is not stored in a readable way, so you need to iterate over each item and get the readable values from them. 
- Is this service part of the domain or infrastructure?
  - Mainly the domain I would say, it creates a necessary object that is part of the data structure, but the methods are also part of the infrastructure.