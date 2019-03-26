import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import WorkOrderMapper from './workOrderMapper';
import WorkOrderViewModel from './workOrderViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { WorkOrderRoutingTableComponent } from '../shared/workOrderRoutingTable';

interface WorkOrderDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface WorkOrderDetailComponentState {
  model?: WorkOrderViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class WorkOrderDetailComponent extends React.Component<
  WorkOrderDetailComponentProps,
  WorkOrderDetailComponentState
> {
  state = {
    model: new WorkOrderViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.WorkOrders + '/edit/' + this.state.model!.workOrderID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.WorkOrderClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.WorkOrders +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new WorkOrderMapper();

        this.setState({
          model: mapper.mapApiResponseToViewModel(response.data),
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
  }

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <div>
          <Button
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div>
              <h3>Due Date</h3>
              <p>{String(this.state.model!.dueDate)}</p>
            </div>
            <div>
              <h3>End Date</h3>
              <p>{String(this.state.model!.endDate)}</p>
            </div>
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Order Qty</h3>
              <p>{String(this.state.model!.orderQty)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Product I D</h3>
              <p>
                {String(
                  this.state.model!.productIDNavigation &&
                    this.state.model!.productIDNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Scrapped Qty</h3>
              <p>{String(this.state.model!.scrappedQty)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Scrap Reason I D</h3>
              <p>
                {String(
                  this.state.model!.scrapReasonIDNavigation &&
                    this.state.model!.scrapReasonIDNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Start Date</h3>
              <p>{String(this.state.model!.startDate)}</p>
            </div>
            <div>
              <h3>Stocked Qty</h3>
              <p>{String(this.state.model!.stockedQty)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>WorkOrderRoutings</h3>
            <WorkOrderRoutingTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.WorkOrders +
                '/' +
                this.state.model!.workOrderID +
                '/' +
                ApiRoutes.WorkOrderRoutings
              }
            />
          </div>
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedWorkOrderDetailComponent = Form.create({
  name: 'WorkOrder Detail',
})(WorkOrderDetailComponent);


/*<Codenesium>
    <Hash>687fa2511ff11cfec3d42bd0774bf90b</Hash>
</Codenesium>*/