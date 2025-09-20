// Dummy data
const projects = [
    {
      id: 1,
      name: "TaskBoard API",
      sprints: [
        { id: 1, 
          name: "Backlog",
          states:[{
            id : 1,
            name:"To Do" 
            },
            {
             id : 2,
             name : "In Progress"
            }
          ],
          tasks: [{
            id:1,
            title:"Intergate auto mapper",
            description:"Make automapper casual",
            tags:["Back", "High"],
            state:"To Do",
            user:"Stelios"
          }]
        },
        { id: 2, name: "Sprint Planning" },
        { id: 3, name: "Sprint 1" }
      ]
    }
  ];

  function applyDND(){
    console.log("applying drag n drop");
    const dropAreas = document.getElementsByClassName("dropArea");
    console.log(dropAreas);
  
    const card = document.querySelector(".moveTask");
  
    card.addEventListener("dragstart", (e) => {
      e.dataTransfer.setData("text/plain", e.target.id);
    });
  
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
  
  const projectLi = document.querySelector("#Projects");
  // Select the Projects li
  //const projectLi = document.querySelector("#Projects");
  
  // Create a container for project dropdown
  const projectListContainer = document.createElement("ul");
  projectListContainer.style.listStyle = "none";
  projectListContainer.style.paddingLeft = "1rem";
  projectListContainer.style.display = "none"; // hidden initially
  projectLi.appendChild(projectListContainer);

  


  // Populate project dropdown
  projects.forEach(project => {
    const li = document.createElement("li");
    li.textContent = project.name;
    li.style.cursor = "pointer";
  
    li.addEventListener("click", (e) => {
      e.stopPropagation();
      populateTaskDropdown(project);
    });
  
    projectListContainer.appendChild(li);
  });
  
  // Toggle project dropdown
  projectLi.addEventListener("click", (e) => {
    e.stopPropagation();
    projectDropdownVisible = !projectDropdownVisible;
    projectListContainer.style.display = projectDropdownVisible ? "block" : "none";
  });
  
  // Function to populate task dropdown
  function populateTaskDropdown(project) {
    // Remove old task dropdown if exists
    const oldTaskList = projectLi.querySelector("ul.task-list");
    if (oldTaskList) oldTaskList.remove();
  
    const taskList = document.createElement("ul");
    taskList.classList.add("task-list");
    taskList.style.listStyle = "none";
    taskList.style.paddingLeft = "1rem";
    taskList.style.marginTop = "0.2rem";
  
    project.sprints.forEach(task => {
      const li = document.createElement("li");
      li.textContent = task.name;
      li.style.cursor = "pointer";
      li.addEventListener("click", (e) => {
        e.stopPropagation();
        loadBoard(task);
      });
      taskList.appendChild(li);
    });
  
    projectLi.appendChild(taskList);
  }
  
  // Close dropdowns if clicked outside
  document.addEventListener("click", () => {
    projectDropdownVisible = false;
    projectListContainer.style.display = "none";
  });
  