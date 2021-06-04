import {UseDocuments} from "../../Hooks/useFetch/use-documents/UseDocuments";
import GetHeader from "../../Hooks/headers";
import { GridComponent, ColumnsDirective, ColumnDirective, Page, ForeignKey, Inject } from '@syncfusion/ej2-react-grids';

export function GetAllDocs() {
    const { loading, data, error } = UseDocuments();
    if (loading) return (<h1>Loading...</h1>);
    if (error) return (
        <pre>{JSON.stringify(error, null, 2)}</pre>
    );
    return (
        (<div className='control-pane'>
        <div className='control-section'>
            <GridComponent dataSource={data} allowPaging={true} pageSettings={{ pageCount: 4 }}>
                <ColumnsDirective>
                    <ColumnDirective field='documentId' headerText='ID' width='50' textAlign='Center'></ColumnDirective>
                    <ColumnDirective field='docTitle' headerText='Title' width='100' textAlign="Left"></ColumnDirective>
                    <ColumnDirective field='dateCreated' headerText='Date Created' width='100' format='yMd' textAlign='Right' />
                    <ColumnDirective field='stateModelId' headerText='Edit  State' width='120' format='C2' textAlign='Right' foreignKeyField='stateModelId' />
                    <ColumnDirective field='dateModified' headerText='Date Modified' width='130' format='yMd' textAlign='Right'></ColumnDirective>
                    <ColumnDirective field='docContent' headerText='Content' width='150'></ColumnDirective>
                </ColumnsDirective>
                <Inject services={[Page, ForeignKey]} />
            </GridComponent>
        </div>
    </div>)
    );
}


// const headers = GetHeader();
// const opts: RequestInit = {
//     method: 'GET',
//     headers,
// };



// export default async function GetAllDocsData(): Promise<Response> {
// const url = "https://localhost:5001/api/documents";
//     return  fetch(url, opts);
// }
