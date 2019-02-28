import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import WorkOrderMapper from './workOrderMapper';
import WorkOrderViewModel from './workOrderViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.WorkOrders +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.WorkOrderClientResponseModel;

          console.log(response);

          let mapper = new WorkOrderMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: true,
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
              <h3>DueDate</h3>
              <p>{String(this.state.model!.dueDate)}</p>
            </div>
            <div>
              <h3>EndDate</h3>
              <p>{String(this.state.model!.endDate)}</p>
            </div>
            <div>
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>OrderQty</h3>
              <p>{String(this.state.model!.orderQty)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>ProductID</h3>
              <p>
                {String(this.state.model!.productIDNavigation!.toDisplay())}
              </p>
            </div>
            <div>
              <h3>ScrappedQty</h3>
              <p>{String(this.state.model!.scrappedQty)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>ScrapReasonID</h3>
              <p>
                {String(this.state.model!.scrapReasonIDNavigation!.toDisplay())}
              </p>
            </div>
            <div>
              <h3>StartDate</h3>
              <p>{String(this.state.model!.startDate)}</p>
            </div>
            <div>
              <h3>StockedQty</h3>
              <p>{String(this.state.model!.stockedQty)}</p>
            </div>
            <div>
              <h3>WorkOrderID</h3>
              <p>{String(this.state.model!.workOrderID)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>WorkOrderRoutings</h3>
            <WorkOrderRoutingTableComponent
              workOrderID={this.state.model!.workOrderID}
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
    <Hash>af763ecc42dcecffa36b2acbba0b5ef6</Hash>
</Codenesium>*/