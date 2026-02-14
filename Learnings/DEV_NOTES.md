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
