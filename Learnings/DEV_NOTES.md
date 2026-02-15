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
  - The list is private in order to ensure that it can only be altered through the methods in the Service. "Encapsulation is about ownership", the list is own and managed by the Service, so it should only be altered by it. 
- Why not return the raw List directly?
  - By returning the raw list directly I make it vulnerable to mutation by external code, encapsulation again. By returning a string[] that is based on the list I protect the actual code by creating a read-only copy. 
- Is this service part of the domain or infrastructure?
  - Mainly the domain I would say, it creates a necessary object that is part of the data structure, but the methods are also part of the infrastructure.
### Step 4: Fix & Strengthen the Service
- Who owns presentation: service or UI?
  - UI owns presentation, service owns the data storage and management.
- Who owns data integrity?
  - At the lowest level, the domain (correct properties etc.), but other than that the service.
- What would break if a GUI used your current service?
  - The GUI would only recieve a giant string of the list data, which it would not be able to transform to separate instances of presentable game objects. 
### Step 5: Pure Data Service
- Why is returning domain objects more powerful than strings?
  - Domain objects come with all the properties in their base types, as well as any methods attached to them. This way the frontend can get the data and properly present it.
  Objects preserve meaning; strings flatten meaning.
- What’s the difference between exposing data and exposing structure?
  - Exposing data → letting others read values
    Exposing structure → letting others control storage
    You want observation without authority.
- Why should a service protect its internal collection type?
  - Encapsulation again, the setter allows external code to completely overwrite the existing collection. 
### Step 6: ReadOnly Exposure
- Why is shared mutable state dangerous?
  - It exposes structure, not data. Two owners = unpredictable behavior.
- What’s the difference between “can read” and “can control”?
  - Can read means get data for observation, while can control means that the data can be set as well.
- Why is returning a copy sometimes worse than returning read-only?
  - Returning a copy is safe — but inefficient and misleading. Read-only interfaces express intent directly.