import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import DocumentMapper from './documentMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import ReactTable from "react-table";
import DocumentViewModel from './documentViewModel';
import "react-table/react-table.css";

interface DocumentSearchComponentProps
{
    history:any;
}

interface DocumentSearchComponentState
{
    records:Array<DocumentViewModel>;
    filteredRecords:Array<DocumentViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class DocumentSearchComponent extends React.Component<DocumentSearchComponentProps, DocumentSearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<DocumentViewModel>(), filteredRecords:new Array<DocumentViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:Api.DocumentClientResponseModel) {
         this.props.history.push(ClientRoutes.Documents + '/edit/' + row.rowguid);
    }

    handleDetailClick(e:any, row:Api.DocumentClientResponseModel) {
         this.props.history.push(ClientRoutes.Documents + '/' + row.rowguid);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.Documents + '/create');
    }

    handleDeleteClick(e:any, row:Api.DocumentClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.Documents + '/' + row.rowguid,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            this.setState({...this.state, deleteResponse:'Record deleted', deleteSuccess:true, deleteSubmitted:true});
            this.loadRecords(this.state.searchValue);
        }, error => {
            console.log(error);
            this.setState({...this.state, deleteResponse:'Error deleting record', deleteSuccess:false, deleteSubmitted:true});
        })
    }

   handleSearchChanged(e:React.FormEvent<HTMLInputElement>) {
		this.loadRecords(e.currentTarget.value);
   }
   
   loadRecords(query:string = '') {
	   this.setState({...this.state, searchValue:query});
	   let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.Documents + '?limit=100';

	   if(query)
	   {
		   searchEndpoint += '&query=' +  query;
	   }

	   axios.get(searchEndpoint,
	   {
		   headers: {
			   'Content-Type': 'application/json',
		   }
	   })
	   .then(resp => {
		    let response = resp.data as Array<Api.DocumentClientResponseModel>;
		    let viewModels : Array<DocumentViewModel> = [];
			let mapper = new DocumentMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<DocumentViewModel>(),filteredRecords:new Array<DocumentViewModel>(), loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
	   })
    }

    filterGrid() {

    }
    
    render () {
        if(this.state.loading) {
            return <LoadingForm />;
        } 
		else if(this.state.errorOccurred) {
            return <ErrorForm message={this.state.errorMessage} />;
        }
        else if(this.state.loaded) {

            let errorResponse:JSX.Element = <span></span>;

            if(this.state.deleteSubmitted){
                if(this.state.deleteSuccess){
                    errorResponse =<div className="alert alert-success">{this.state.deleteResponse}</div>   
                }
                else {
                    errorResponse = <div className="alert alert-danger">{this.state.deleteResponse}</div>   
                }
            }
            return (
            <div>
                { 
                    errorResponse
                }
            <form>
                <div className="form-group row">
                    <div className="col-sm-4">
                    </div>
                    <div className="col-sm-4">
                        <input name="search" className="form-control" placeholder={"Search"} value={this.state.searchValue} onChange={e => this.handleSearchChanged(e)}/>
                    </div>
                    <div className="col-sm-4">
                        <button className="btn btn-primary btn-sm align-middle float-right vertically-center search-create-button" onClick={e => this.handleCreateClick(e)}><i className="fas fa-plus"></i></button>
                    </div>
                </div>
            </form>
            <ReactTable 
                data={this.state.filteredRecords}
                columns={[{
                    Header: 'Document',
                    columns: [
					  {
                      Header: 'ChangeNumber',
                      accessor: 'changeNumber',
                      Cell: (props) => {
                      return <span>{String(props.original.changeNumber)}</span>;
                      }           
                    },  {
                      Header: 'Document',
                      accessor: 'document1',
                      Cell: (props) => {
                      return <span>{String(props.original.document1)}</span>;
                      }           
                    },  {
                      Header: 'DocumentLevel',
                      accessor: 'documentLevel',
                      Cell: (props) => {
                      return <span>{String(props.original.documentLevel)}</span>;
                      }           
                    },  {
                      Header: 'DocumentSummary',
                      accessor: 'documentSummary',
                      Cell: (props) => {
                      return <span>{String(props.original.documentSummary)}</span>;
                      }           
                    },  {
                      Header: 'FileExtension',
                      accessor: 'fileExtension',
                      Cell: (props) => {
                      return <span>{String(props.original.fileExtension)}</span>;
                      }           
                    },  {
                      Header: 'FileName',
                      accessor: 'fileName',
                      Cell: (props) => {
                      return <span>{String(props.original.fileName)}</span>;
                      }           
                    },  {
                      Header: 'FolderFlag',
                      accessor: 'folderFlag',
                      Cell: (props) => {
                      return <span>{String(props.original.folderFlag)}</span>;
                      }           
                    },  {
                      Header: 'ModifiedDate',
                      accessor: 'modifiedDate',
                      Cell: (props) => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                      }           
                    },  {
                      Header: 'Owner',
                      accessor: 'owner',
                      Cell: (props) => {
                      return <span>{String(props.original.owner)}</span>;
                      }           
                    },  {
                      Header: 'Revision',
                      accessor: 'revision',
                      Cell: (props) => {
                      return <span>{String(props.original.revision)}</span>;
                      }           
                    },  {
                      Header: 'Rowguid',
                      accessor: 'rowguid',
                      Cell: (props) => {
                      return <span>{String(props.original.rowguid)}</span>;
                      }           
                    },  {
                      Header: 'Status',
                      accessor: 'status',
                      Cell: (props) => {
                      return <span>{String(props.original.status)}</span>;
                      }           
                    },  {
                      Header: 'Title',
                      accessor: 'title',
                      Cell: (props) => {
                      return <span>{String(props.original.title)}</span>;
                      }           
                    },
                    {
                        Header: 'Actions',
                        Cell: row => (<div><button className="btn btn-sm" onClick={e => {this.handleDetailClick(e, row.original as Api.DocumentClientResponseModel)}} ><i className="fas fa-search"></i></button>
                        &nbsp;<button className="btn btn-primary btn-sm" onClick={e => {this.handleEditClick(e, row.original as Api.DocumentClientResponseModel)}} ><i className="fas fa-edit"></i></button>
                        &nbsp;<button className="btn btn-danger btn-sm" onClick={e => {this.handleDeleteClick(e, row.original as Api.DocumentClientResponseModel)}} ><i className="far fa-trash-alt"></i></button>
                        </div>)
                    }],
                    
                  }]} />
                  </div>);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>3f610200528f951362977c9996450ebf</Hash>
</Codenesium>*/