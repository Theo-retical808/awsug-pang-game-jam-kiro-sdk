# AI Workflow: Adding a New Feature

## Process (Optimized for Credit Efficiency)

### Step 1: Plan (0 credits)
Decide exactly what you want before talking to AI:
- What does the feature do?
- Which files need to change?
- What's the data model?

### Step 2: Create the Data Model (1 credit)
```
Create [Feature]/[Name]Data.cs with:
- [list properties]
- [list relationships]
```

### Step 3: Create the Manager (1 credit)
```
Create [Feature]/[Name]Manager.cs with:
- Constructor that initializes [data]
- [Method 1] that does [behavior]
- [Method 2] that does [behavior]
- Event for [state change]
```

### Step 4: Wire into UI (1 credit)
```
In Forms/[Form].cs:
- Add a button/panel for [feature]
- On click, call [Manager].[Method]
- Update display when [event] fires
```

### Step 5: Test & Polish (0-1 credits)
- Run the game and test
- If bugs, use 1 credit to fix
- If working, move on

## Total: 3-4 credits for a complete feature

## Example: Adding an Inventory

1. Plan: Items with name, description, icon. Max 20 slots. Show in side panel.
2. "Create Items/ItemData.cs with Name, Description, Rarity, and StackSize properties"
3. "Create Items/InventoryManager.cs with AddItem, RemoveItem, GetItems, IsFull methods and OnInventoryChanged event"
4. "In Forms/BattleForm.cs, add an inventory button that opens a new InventoryPanel showing all items as a list"
