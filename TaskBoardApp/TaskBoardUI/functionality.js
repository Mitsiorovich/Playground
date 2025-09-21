// Dummy data
const projects = [
  {
    id: 1,
    name: "TaskBoard API",
    sprints: [
      {
        id: 1,
        name: "Backlog",
        states: [
          { id: 1, name: "To Do" },
          { id: 2, name: "In Progress" },
          { id: 3, name: "Done" }
        ],
        tasks: [
          {
            id: 1,
            title: "Integrate AutoMapper",
            description: "Set up AutoMapper profiles for DTO mapping.",
            tags: ["Backend", "High"],
            state: "To Do",
            user: "Stelios"
          },
          {
            id: 2,
            title: "Create API Documentation",
            description: "Document all endpoints with Swagger.",
            tags: ["Backend", "Medium"],
            state: "To Do",
            user: "Maria"
          }
        ]
      },
      {
        id: 2,
        name: "Sprint Planning",
        states: [
          { id: 4, name: "To Do" },
          { id: 5, name: "In Progress" },
          { id: 6, name: "Done" }
        ],
        tasks: [
          {
            id: 3,
            title: "Define Sprint Goals",
            description: "List all objectives for this sprint.",
            tags: ["Planning", "High"],
            state: "In Progress",
            user: "Stelios"
          }
        ]
      },
      {
        id: 3,
        name: "Sprint 1",
        states: [
          { id: 7, name: "To Do" },
          { id: 8, name: "In Progress" },
          { id: 9, name: "Done" }
        ],
        tasks: [
          {
            id: 4,
            title: "Setup Database",
            description: "Configure PostgreSQL and initial tables.",
            tags: ["Backend", "High"],
            state: "Done",
            user: "Maria"
          },
          {
            id: 5,
            title: "Create User Authentication",
            description: "Implement JWT login/logout.",
            tags: ["Backend", "High"],
            state: "In Progress",
            user: "Stelios"
          },
          {
            id: 6,
            title: "Design Login Page",
            description: "Create UI mockups for login and registration.",
            tags: ["Frontend", "Medium"],
            state: "To Do",
            user: "Alex"
          }
        ]
      }
    ]
  },
  {
    id: 2,
    name: "Web Dashboard",
    sprints: [
      {
        id: 4,
        name: "Backlog",
        states: [
          { id: 10, name: "To Do" },
          { id: 11, name: "In Progress" },
          { id: 12, name: "Done" }
        ],
        tasks: [
          {
            id: 7,
            title: "Set up React App",
            description: "Initialize project with Create React App.",
            tags: ["Frontend", "High"],
            state: "To Do",
            user: "Alex"
          },
          {
            id: 8,
            title: "Create Sidebar Menu",
            description: "Implement navigation for dashboard pages.",
            tags: ["Frontend", "Medium"],
            state: "To Do",
            user: "Maria"
          }
        ]
      },
      {
        id: 5,
        name: "Sprint 1",
        states: [
          { id: 13, name: "To Do" },
          { id: 14, name: "In Progress" },
          { id: 15, name: "Done" }
        ],
        tasks: [
          {
            id: 9,
            title: "Connect API to Dashboard",
            description: "Fetch project and task data via Axios.",
            tags: ["Frontend", "High"],
            state: "In Progress",
            user: "Stelios"
          },
          {
            id: 10,
            title: "Add Drag & Drop",
            description: "Enable moving tasks between columns.",
            tags: ["Frontend", "High"],
            state: "To Do",
            user: "Alex"
          }
        ]
      }
    ]
  }
];


  function applyDND(){
    console.log("applying drag n drop");
    const dropAreas = document.getElementsByClassName("dropArea");
    console.log(dropAreas);
  
    const cards = document.querySelectorAll(".moveTask");
  
    for (let i= 0; i < cards.length; i++) {
        cards[i].addEventListener("dragstart", (e) => {
        e.dataTransfer.setData("text/plain", e.target.id);
      });
    }
    
  
    for (let i = 0; i < dropAreas.length; i++) {
      console.log("assigning a lsitener");
      dropAreas[i].addEventListener("dragover", (e) => {
        e.preventDefault();
        console.log("can drop here");
      });
    }
  
    for (let i = 0; i < dropAreas.length; i++) {
      console.log("assigning a drop lsitener");
      dropAreas[i].addEventListener("drop", (e) => {
          e.preventDefault();
          console.log("just dropped"); 
          const cardId = e.dataTransfer.getData("text/plain");
          const card = document.getElementById(cardId);
          console.log(card);
          dropAreas[i]
          .getElementsByClassName("cards")[0]
          .append(card);// μετακινεί την κάρτα
        });
    }
  };

  applyDND();

  function loadBoard(sprint) {
    let boardContainer = document.querySelector(".board");

    boardContainer.innerHTML = "";
    sprint.states.forEach((state)=>{
        let column = newSprintColumn(state);
        boardContainer.insertAdjacentHTML("beforeend", column);
    });

    sprint.tasks.forEach((task)=>{
        let taskCard = newTaskCard(task);
        let attachToColumn = document.querySelector(`[data-name="${task.state}"]`);
        attachToColumn.getElementsByClassName("cards")[0].insertAdjacentHTML("beforeend",taskCard);
    })

    applyDND();
  }

  function newSprintColumn(state){
    const column = state;
    return `<section id="columnNo_${column.id}" data-name="${column.name}" class="list dropArea">
      <header class="list-header">
        <h2>${column.name}</h2>
        <button class="add-card">+ Add Card</button>
      </header>
      <div class="cards">
      </div>
    </section>`
  }

  function newTaskCard(task){
    return `<article id="taskNo_${task.id}" class="card moveTask" draggable="true">
          <h3 class="card-title">${task.title}</h3>
          <p class="card-desc">${task.description}</p>
          <div class="tags">
                ${task.tags.map(tag => `<span class="tag ${tag.toLowerCase()}">${tag}</span>`).join('')}
            </div>
          <div class="card-footer">
            <span class="avatar">${task.user}</span>
          </div>
        </article>`;
  }

 
  // State for dropdown visibility
let projectDropdownVisible = false;
let taskDropdownVisible = false;
  

// === Select the Projects li ===
const projectLi = document.querySelector("#Projects");
let activeTAB = null;
let activeSUBTAB = null;
let activeBOARD = null;

// === Create Project Dropdown Container ===
const projectListContainer = document.createElement("ul");
projectListContainer.classList.add("dropdown-list");
projectLi.appendChild(projectListContainer);
projectListContainer.style.display = "none"; // hidden initially

// === Toggle Project Dropdown visibility ===
projectLi.addEventListener("click", () => {
  // Manage active tab
  projectLi.classList.add("is-active-tab");
  if (activeTAB !== null && activeTAB !== projectLi) {
    activeTAB.classList.remove("is-active-tab");
  }
  activeTAB = projectLi;

  const isHidden = projectListContainer.style.display === "none";
  projectListContainer.style.display = isHidden ? "block" : "none";

  if (!isHidden) {
    // Closing Projects dropdown → hide sprint lists
    const sprintLists = projectListContainer.querySelectorAll("ul");
    sprintLists.forEach(sprintList => {
      sprintList.style.display = "none";
    });

    // Remove all sub-tab active states unless they have an active board inside
    const activeSubTabs = projectListContainer.querySelectorAll(".is-active-sub-tab");
    activeSubTabs.forEach(tab => {
      const hasActiveBoard = tab.querySelector(".is-active-board") !== null;
      if (!hasActiveBoard) {
        tab.classList.remove("is-active-sub-tab");
      }
    });
  } else {
    // Re-opening Projects dropdown → expand the project that has an active board
    if (activeBOARD) {
      const parentProject = activeBOARD.closest(".project-item");
      const sprintList = parentProject.querySelector("ul");
      parentProject.classList.add("is-active-sub-tab");
      sprintList.style.display = "block";
    }
  }
});

// === Populate Projects Dropdown ===
projects.forEach(project => {
  const projItem = document.createElement("li");
  projItem.textContent = project.name;
  projItem.classList.add("project-item");

  // Create Sprint container for this project
  const sprintList = document.createElement("ul");
  projItem.appendChild(sprintList);
  sprintList.style.display = "none"; // hidden initially

  // Toggle Sprint visibility
  projItem.addEventListener("click", (e) => {
    projItem.classList.toggle("is-active-sub-tab");
    e.stopPropagation(); // prevent parent toggles
    sprintList.style.display = sprintList.style.display === "none" ? "block" : "none";
  });

  // Populate Sprints
  project.sprints?.forEach(sprint => {
    const sprintItem = document.createElement("li");
    sprintItem.textContent = sprint.name;
    sprintItem.classList.add("sprint-item");

    // Click listener to load board
    sprintItem.addEventListener("click", (e) => {
      sprintItem.classList.add("is-active-board");
      if (activeBOARD && activeBOARD !== sprintItem) {
        activeBOARD.classList.remove("is-active-board");
      }
      activeBOARD = sprintItem;

      e.stopPropagation(); // prevent bubbling
      loadBoard(sprint);   // <-- load this sprint's board
    });

    sprintList.appendChild(sprintItem);
  });

  projectListContainer.appendChild(projItem);
});
