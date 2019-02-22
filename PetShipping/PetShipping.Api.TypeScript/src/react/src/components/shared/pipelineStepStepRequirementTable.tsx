import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PipelineStepStepRequirementMapper from '../pipelineStepStepRequirement/pipelineStepStepRequirementMapper';
import PipelineStepStepRequirementViewModel from '../pipelineStepStepRequirement/pipelineStepStepRequirementViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface PipelineStepStepRequirementTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface PipelineStepStepRequirementTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<PipelineStepStepRequirementViewModel>;
}

export class  PipelineStepStepRequirementTableComponent extends React.Component<
PipelineStepStepRequirementTableComponentProps,
PipelineStepStepRequirementTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: PipelineStepStepRequirementViewModel) {
  this.props.history.push(ClientRoutes.PipelineStepStepRequirements + '/edit/' + row.id);
}

handleDetailClick(e:any, row: PipelineStepStepRequirementViewModel) {
  this.props.history.push(ClientRoutes.PipelineStepStepRequirements + '/' + row.id);
}

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Array<Api.PipelineStepStepRequirementClientResponseModel>;

          console.log(response);

          let mapper = new PipelineStepStepRequirementMapper();
          
          let pipelineStepStepRequirements:Array<PipelineStepStepRequirementViewModel> = [];

          response.forEach(x =>
          {
              pipelineStepStepRequirements.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: pipelineStepStepRequirements,
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    
	let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
       return <Spin size="large" />;
    }
	else if (this.state.errorOccurred) {
	  return <Alert message={this.state.errorMessage} type='error' />;
	}
	 else if (this.state.loaded) {
      return (
	  <div>
		{message}
         <ReactTable 
                data={this.state.filteredRecords}
				defaultPageSize={10}
                columns={[{
                    Header: 'PipelineStepStepRequirements',
                    columns: [
					  {
                      Header: 'Details',
                      accessor: 'detail',
                      Cell: (props) => {
                      return <span>{String(props.original.detail)}</span>;
                      }           
                    },  {
                      Header: 'Id',
                      accessor: 'id',
                      Cell: (props) => {
                      return <span>{String(props.original.id)}</span>;
                      }           
                    },  {
                      Header: 'PipelineStepId',
                      accessor: 'pipelineStepId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.PipelineSteps + '/' + props.original.pipelineStepId); }}>
                          {String(
                            props.original.pipelineStepIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'RequirementMet',
                      accessor: 'requirementMet',
                      Cell: (props) => {
                      return <span>{String(props.original.requirementMet)}</span>;
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
                              row.original as PipelineStepStepRequirementViewModel
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
                              row.original as PipelineStepStepRequirementViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                        </div>)
                    }],
                    
                  }]} />
			</div>
      );
    } else {
      return null;
    }
  }
}

/*<Codenesium>
    <Hash>f799d07bd16d805ed7684d712aef175f</Hash>
</Codenesium>*/