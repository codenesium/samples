import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import NoteMapper from './noteMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from "react-table";
import NoteViewModel from './noteViewModel';
import "react-table/react-table.css";
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface NoteSearchComponentProps
{
     form:WrappedFormUtils;
	 history:any;
	 match:any;
}

interface NoteSearchComponentState
{
    records:Array<NoteViewModel>;
    filteredRecords:Array<NoteViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class NoteSearchComponent extends React.Component<NoteSearchComponentProps, NoteSearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<NoteViewModel>(), filteredRecords:new Array<NoteViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:NoteViewModel) {
         this.props.history.push(ClientRoutes.Notes + '/edit/' + row.id);
    }

    handleDetailClick(e:any, row:NoteViewModel) {
         this.props.history.push(ClientRoutes.Notes + '/' + row.id);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.Notes + '/create');
    }

    handleDeleteClick(e:any, row:Api.NoteClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.Notes + '/' + row.id,
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
	   let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.Notes + '?limit=100';

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
		    let response = resp.data as Array<Api.NoteClientResponseModel>;
		    let viewModels : Array<NoteViewModel> = [];
			let mapper = new NoteMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<NoteViewModel>(), filteredRecords:new Array<NoteViewModel>(), loading:false, loaded:true, errorOccurred:true, errorMessage:'Error from API'});
	   })
    }

    filterGrid() {

    }
    
    render () {
        if(this.state.loading) {
            return <Spin size="large" />;
        } 
		else if(this.state.errorOccurred) {
            return <Alert message={this.state.errorMessage} type="error" />
        }
        else if(this.state.loaded) {

            let errorResponse:JSX.Element = <span></span>;

            if (this.state.deleteSubmitted) {
				if (this.state.deleteSuccess) {
				  errorResponse = (
					<Alert message={this.state.deleteResponse} type="success" style={{marginBottom:"25px"}} />
				  );
				} else {
				  errorResponse = (
					<Alert message={this.state.deleteResponse} type="error" style={{marginBottom:"25px"}} />
				  );
				}
			}
            
			return (
            <div>
            {errorResponse}
            <Row>
				<Col span={8}></Col>
				<Col span={8}>   
				   <Input 
					placeholder={"Search"} 
					id={"search"} 
					onChange={(e:any) => {
					  this.handleSearchChanged(e)
				   }}/>
				</Col>
				<Col span={8}>  
				  <Button 
				  style={{'float':'right'}}
				  type="primary" 
				  onClick={(e:any) => {
                        this.handleCreateClick(e)
						}}
				  >
				  +
				  </Button>
				</Col>
			</Row>
			<br />
			<br />
            <ReactTable 
                data={this.state.filteredRecords}
                columns={[{
                    Header: 'Notes',
                    columns: [
					  {
                      Header: 'CallId',
                      accessor: 'callId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Calls + '/' + props.original.callId); }}>
                          {String(
                            props.original.callIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'DateCreated',
                      accessor: 'dateCreated',
                      Cell: (props) => {
                      return <span>{String(props.original.dateCreated)}</span>;
                      }           
                    },  {
                      Header: 'NoteText',
                      accessor: 'noteText',
                      Cell: (props) => {
                      return <span>{String(props.original.noteText)}</span>;
                      }           
                    },  {
                      Header: 'OfficerId',
                      accessor: 'officerId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Officers + '/' + props.original.officerId); }}>
                          {String(
                            props.original.officerIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },
                    {
                        Header: 'Actions',
                        Cell: row => (<div>
					    <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleDetailClick(
                              e,
                              row.original as NoteViewModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </Button>
                        &nbsp;
                        <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleEditClick(
                              e,
                              row.original as NoteViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                        &nbsp;
                        <Button
                          type="danger" 
                          onClick={(e:any) => {
                            this.handleDeleteClick(
                              e,
                              row.original as NoteViewModel
                            );
                          }}
                        >
                          <i className="far fa-trash-alt" />
                        </Button>

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

export const WrappedNoteSearchComponent = Form.create({ name: 'Note Search' })(NoteSearchComponent);

/*<Codenesium>
    <Hash>d64291439de819aac48d7008e903c593</Hash>
</Codenesium>*/