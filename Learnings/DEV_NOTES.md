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
### Step 7: Introduce MediaItem Base Class
- Why make MediaItem abstract?
  - MediaItem is a categorization of a certain type of item, not a physical thing itself. We dont want to create an instance of MediaItem, just instances of its child classes.
- What does inheritance buy us here?
  - Inheritance centralizes shared state and behavior in the parent class, while also making it easier to add new child classes in the future, especially with a polymorphic service.
- What would composition look like instead?
  - Composition would look more like:
    ```
    VideoGame HAS-A Rating
    VideoGame HAS-A PlatformInfo
    VideoGame HAS-A MediaMetadata
    ```
    instead of:
    ```
    VideoGame IS-A MediaItem
    ```
  - Composition models assembly. Inheritance models categorization.
### Step 8: Real Polymorphism
- What problem does polymorphism solve here?
  - Polymorphism allows us to use the same method for presenting and transforming multiple class types, thus reducing duplication.
  - Code stops caring about concrete types.
- Why is removing casts important?
  - Casts can cause errors when not following the item structure exactly, creating more fragile code. 
  - Casts reveal abstraction failure.
- When might inheritance become the wrong choice?
  - When an object gets too different, and doesn't share any common traits with the other children. 
  - Shared behavior is artificial
  - Child types diverge heavily
  - Hierarchy becomes rigid
### Step 9: Refactor Object Creation
- Why do large methods become dangerous?
  - Large methods that have too many responsibilities become harder to maintain, and are less debug-friendly. It is also easier to get into the habit of patching edge-cases, and then having to work around them. 
- What duplication is worth removing vs acceptable?
  - Exact duplication, like title and rating in this instance are worth extracting because we determined they will always be present in the objects. When it isn't an exact duplication, extaction is more risky.
- What’s the difference between abstraction and over-engineering?
  - Essentially, if the solution fits easily and makes the code feel more streamlined, it's good abstraction. If the solution feels hamfisted or forced, it's probably over-engineered.