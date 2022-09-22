const WorkItem = ({ workItem }) => {
    return (
        <h3>{workItem.workItemType} - {workItem.title} - {workItem.workItemState}</h3>
    )
}

export default WorkItem