import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import HandlerPipelineStepMapper from '../handlerPipelineStep/handlerPipelineStepMapper';
import HandlerPipelineStepViewModel from '../handlerPipelineStep/handlerPipelineStepViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface HandlerPipelineStepTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface HandlerPipelineStepTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<HandlerPipelineStepViewModel>;
}

export class  HandlerPipelineStepTableComponent extends React.Component<
HandlerPipelineStepTableComponentProps,
HandlerPipelineStepTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: HandlerPipelineStepViewModel) {
  this.props.history.push(ClientRoutes.HandlerPipelineSteps + '/edit/' + row.id);
}

handleDetailClick(e:any, row: HandlerPipelineStepViewModel) {
  this.props.history.push(ClientRoutes.HandlerPipelineSteps + '/' + row.id);
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
          let response = resp.data as Array<Api.HandlerPipelineStepClientResponseModel>;

          console.log(response);

          let mapper = new HandlerPipelineStepMapper();
          
          let handlerPipelineSteps:Array<HandlerPipelineStepViewModel> = [];

          response.forEach(x =>
          {
              handlerPipelineSteps.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: handlerPipelineSteps,
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
                    Header: 'HandlerPipelineSteps',
                    columns: [
					  {
                      Header: 'HandlerId',
                      accessor: 'handlerId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Handlers + '/' + props.original.handlerId); }}>
                          {String(
                            props.original.handlerIdNavigation.toDisplay()
                          )}
                        </a>
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
                    },
                    {
                        Header: 'Actions',
                        Cell: row => (<div>
					    <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleDetailClick(
                              e,
                              row.original as HandlerPipelineStepViewModel
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
                              row.original as HandlerPipelineStepViewModel
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
    <Hash>d1530e1a6f87a72472c40c8e16d444d2</Hash>
</Codenesium>*/